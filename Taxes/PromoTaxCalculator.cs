using Agility.Web.eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agility.Web.eCommerce.Taxes
{
    public class PromoTaxCalculator : TaxCalculator
    {
        public PromoTaxCalculator(Func<OrderItem, ITaxRate> taxRateLookup)
            : base(taxRateLookup)
        {
        }

        public PromoTaxCalculator(IEnumerable<ITaxable> tickets)
            : base(tickets)
        {
        }

        public override Tax CalculateTaxAmount(Order order)
        {
            if (order == null)
            {
                return null;
            }

            var totalItemPromoValue = 0;

            var totalItemPrice = 0;

            // first pass: update the price/gate price item 
            // with promo values
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.PriceOverrideMinorUnits -= orderItem.PromoValueMinorUnits;
                orderItem.ProductPriceMinorUnits -= orderItem.PromoValueMinorUnits;

                var itemPrice = GetItemPrice(orderItem);

                if (orderItem.IsRefund)
                {
                    totalItemPrice -= orderItem.Quantity * itemPrice;
                    totalItemPromoValue -= orderItem.PromoValueMinorUnits * orderItem.Quantity;
                }
                else
                {
                    totalItemPrice += orderItem.Quantity * itemPrice;
                    totalItemPromoValue += orderItem.PromoValueMinorUnits * orderItem.Quantity;
                }
            }

            // calculate the difference between the order promo value
            // and the total promo item value
            var diffPromoValue = order.TotalPromotionalValueMinorUnits - totalItemPromoValue;

            // second pass: re-apply the difference to the order items
            var leftOverPromoValue = diffPromoValue;

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.Quantity > 0 && totalItemPrice > 0)
                {
                    var itemPrice = GetItemPrice(orderItem);

                    // calculate a weight to calculate the difference proportionally to
                    // the item price vs quantity
                    var weightPrice = (((decimal)(itemPrice * orderItem.Quantity) / (totalItemPrice)) * 10000);

                    // calculate the value from the difference that should be re-applied
                    // to each order item
                    var diffPrice = (int)Math.Round(((decimal)((diffPromoValue * weightPrice) / 10000) / orderItem.Quantity), 0);

                    leftOverPromoValue -= diffPrice * orderItem.Quantity;

                    if (orderItem.PriceOverrideMinorUnits.HasValue)
                    {
                        orderItem.PriceOverrideMinorUnits -= diffPrice;
                    }
                    else
                    {
                        orderItem.ProductPriceMinorUnits -= diffPrice;
                    }
                }
            }

            // if we have a leftover value of 1, it means
            // one cent was not applied. So, let's apply
            // the left over to the last order item
            if (leftOverPromoValue == 1 && order.OrderItems.Count > 0)
            {
                var lastItem = order.OrderItems[order.OrderItems.Count - 1];

                if (lastItem.PriceOverrideMinorUnits.HasValue)
                {
                    lastItem.PriceOverrideMinorUnits -= leftOverPromoValue;
                }
                else
                {
                    lastItem.ProductPriceMinorUnits -= leftOverPromoValue;
                }
            }

            // third pass: re-use the same tax calculation algorithm
            // to calculate the taxes
            var taxResult = base.CalculateTaxAmount(order);

            return taxResult;
        }
    }
}