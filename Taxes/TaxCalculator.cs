using Agility.Web.eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agility.Web.eCommerce.Taxes
{
    public class TaxCalculator : ITaxCalculator
    {
        protected Func<OrderItem, ITaxRate> taxRateLookup = null;

        public IEnumerable<ITaxable> Tickets { get; private set; }

        public Dictionary<int, ITaxRate> IndexedTaxRates { get; private set; }

        public string GateKeyName { get; set; } = "Gate";

        public TaxCalculator(IEnumerable<ITaxable> taxableItems)
        {
            BuildIndexedRates(taxableItems);

            taxRateLookup = (orderItem) =>
            {
                ITaxRate taxRate = null;

                if (orderItem != null)
                {
                    var taxRateKey = orderItem.VariantOfTicketID == -1
                        ? orderItem.TicketID
                        : orderItem.VariantOfTicketID;

                    taxRate = IndexedTaxRates != null && IndexedTaxRates.ContainsKey(taxRateKey)
                        ? IndexedTaxRates[taxRateKey]
                        : null;
                }

                return taxRate;
            };
        }

        public TaxCalculator(Func<OrderItem, ITaxRate> taxRateLookup)
        {
            if (taxRateLookup == null)
            {
                throw new ArgumentNullException(nameof(taxRateLookup));
            }

            this.taxRateLookup = taxRateLookup;
        }

        public virtual Tax CalculateTaxAmount(Order order)
        {
            Tax taxResult = null;

            if (order != null && taxRateLookup != null)
            {
                taxResult = new Tax();

                foreach (var orderItem in order.OrderItems)
                {
                    var taxRate = taxRateLookup(orderItem);

                    var taxAmount = CalculateTaxAmount(orderItem, taxRate);

                    var savingsTaxAmount = CalculateSavingsTaxAmount(orderItem, taxRate);

                    taxResult.OrderItems.Add(new TaxItem()
                    {
                        OrderItemID = orderItem.OrderItemID,

                        TaxValueMinorUnits = taxAmount,

                        TaxRateMinorUnits = taxRate != null ? (int)taxRate.Rate : 0,

                        TaxRateFinanceKey = taxRate != null ? taxRate.FinanceKey : string.Empty,

                        TicketID = orderItem.TicketID,

                        TicketVariantMeasureID = orderItem.TicketVariantMeasureID,

                        Title = taxRate != null ? taxRate.Title : string.Empty
                    });

                    if (orderItem.IsRefund)
                    {
                        taxResult.TaxAmountMinorUnits -= taxAmount;
                    }
                    else
                    {
                        taxResult.TaxAmountMinorUnits += taxAmount;
                    }

                    taxResult.Custom.TotalSavingsTaxAmountMinorUnits += savingsTaxAmount;
                }
            }

            return taxResult;
        }

        protected virtual int CalculateSavingsTaxAmount(OrderItem orderItem, ITaxRate taxRate)
        {
            int taxAmountAsInt = 0;

            long itemPrice = GetItemPrice(orderItem);

            //TODO: Do not hardcode "gate"
            var gatePrice = orderItem.AltPrices.FirstOrDefault(
                ap => ap.Key.ToLowerInvariant() == GateKeyName.Trim().ToLowerInvariant());

            if (taxRateLookup != null)
            {
                if (gatePrice != null && taxRate != null)
                {
                    var differenceInAmounts = gatePrice.PriceMinorUnits - itemPrice;

                    if (differenceInAmounts > 0)
                    {
                        taxAmountAsInt = (int)Math.Round((decimal)((differenceInAmounts * orderItem.Quantity) * (int)taxRate.Rate) / 10000, 0);
                    }
                }
            }

            return taxAmountAsInt;
        }

        public virtual long CalculateTaxAmount(OrderItem orderItem)
        {
            var taxRate = taxRateLookup(orderItem);

            return CalculateTaxAmount(orderItem, taxRate);
        }

        protected virtual long CalculateTaxAmount(OrderItem orderItem, ITaxRate taxRate)
        {
            var taxAmountAsInt = 0L;

            long itemPrice = GetItemPrice(orderItem);

            if (taxRateLookup != null)
            {
                if (taxRate != null)
                {
                    var taxAmount = (long)taxRate.Rate;

                    taxAmountAsInt = (int)Math.Round((decimal)(itemPrice * orderItem.Quantity * taxAmount) / 10000, 0);
                }
            }

            return taxAmountAsInt;
        }

        public virtual int GetItemPrice(OrderItem orderItem)
        {
            var itemPrice = orderItem.PriceOverrideMinorUnits.HasValue
                ? orderItem.PriceOverrideMinorUnits.Value
                : orderItem.ProductPriceMinorUnits;

            return itemPrice;
        }

        protected virtual void BuildIndexedRates(IEnumerable<ITaxable> tickets)
        {
            IndexedTaxRates = new Dictionary<int, ITaxRate>();

            if (tickets != null)
            {
                foreach (var ticket in tickets)
                {
                    if (!IndexedTaxRates.ContainsKey(ticket.TaxableID))
                    {
                        // create a copy of the tax rate first and
                        // then multiply by 100.
                        // otherwise, this will cause side effects.
                        var taxRate = new BridgeTaxRate()
                        {
                            Title = ticket.TaxRate.Title,
                            Rate = ticket.TaxRate.Rate * 100,
                            FinanceKey = ticket.TaxRate.FinanceKey
                        };

                        IndexedTaxRates.Add(ticket.TaxableID, taxRate);
                    }
                }
            }
        }
    }
}
