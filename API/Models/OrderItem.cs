using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderItem : ModelBase
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int TicketID { get; set; }

        public string ProductDescription { get; set; }
        public int? PriceOverrideMinorUnits { get; set; }
        public int Quantity { get; set; }

        public bool IsRefund { get; set; }

        public string Sku { get; set; }

        //price from the product - converted to the currency of the ORDER
        public int ProductPriceMinorUnits { get; set; }

        /*
		 * Calculated Values for the Invoice
		 */
        public int ItemTotalMinorUnits { get; set; }
        public int PromoValueMinorUnits { get; set; }


        public int VariantOfProductID { get; set; }

        public int VariantOfTicketID { get; set; }

        /// <summary>
        /// Set to True on Order_Get when a Product or Ticket is attached to this order that Requires Manual Fulfillment.
        /// </summary>
        public bool RequiresManualFulfillment { get; set; }


        /// <summary>
        /// The variant measure value - either for the Product or the Ticket - whichever is attached to this Order Item.
        /// </summary>
        public string Measure { get; set; }

        public int ProductVariantMeasureID { get; set; }
        public string ProductVariantMeasureUnitTitle { get; set; }
        public string ProductVariantTitle { get; set; }

        public int TicketVariantMeasureID { get; set; }
        public string TicketVariantMeasureUnitTitle { get; set; }
        public string TicketVariantTitle { get; set; }

        public List<AltPrice> AltPrices = new List<AltPrice>();

        public int TaxRateMinorUnits { get; set; }
        public string ExternalTaxID { get; set; }
        public int TaxValueMinorUnits { get; set; }

        public int? OrderItemStatusID { get; set; }

        public string AdditionalJSON { get; set; }


    }
}
