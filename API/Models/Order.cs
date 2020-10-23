using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Order : ModelBase
    {

        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerID { get; set; }
        public int? ShippingAddressID { get; set; }
        public int? BillingAddressID { get; set; }
        public int OrderStatusID { get; set; }
        public int CurrencyID { get; set; }
        public int SubscriptionID { get; set; }
        public string SubscriptionNumber { get; set; }
        public Currency Currency { get; set; }
        public string Referrer { get; set; }
        public string IPAddress { get; set; }

        public int TotalAmountRefundedMinorUnits { get; set; }


        public int ShippingCostMinorUnits { get; set; }
        public string ShippingDescription { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? ShippingEstimatedArrivalDate { get; set; }

        public int TaxAmountMinorUnits { get; set; }
        public string TaxDescription { get; set; }

        public string TrackingNumber { get; set; }
        public string TrackingURL { get; set; }

        public string Notes { get; set; }
        /// <summary>
        /// Field to Store a JSON object that will need to be serialized/deserialized outside of the regular Ecom API.
        /// </summary>
        public string AdditionalJSON { get; set; }

        public bool QAMode { get; set; } //indicates orders created in QAMode

        public DateTime? SubmittedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public List<OrderItem> OrderItems = new List<OrderItem>();

        public List<int> PromotionIDs = new List<int>();

        public List<Promotion> Promotions = new List<Promotion>();

        public Customer Customer { get; set; }

        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public TerminalOrder TerminalOrder { get; set; }
        /*
		 * Calculated Values for the Invoice - saved to the database only when the order is submitted
		 */

        public int TotalValueMinorUnits { get; set; }
        public int TotalPromotionalValueMinorUnits { get; set; }
        public int SubTotalValueMinorUnits { get; set; }

        public int QuantityRefundable { get; set; }

        /// <summary>
        /// The total amount paid in transactions on this item.  Takes into account refunds as well.
        /// This value is ONLY Calculated in AdminRepo.
        /// </summary>
        public int TotalAmountPaidMinorUnits { get; set; }

        /// <summary>
		/// The total amount pre-authorized in transactions on this item.  Takes into account refunds as well.
		/// This value is ONLY Calculated in AdminRepo.
		/// </summary>
		public int TotalAmountPreauthorizedMinorUnits { get; set; }

        public bool RequiresManualFulfillment()
        {
            bool requiresManualFulfillment = false;

            if (OrderItems?.FirstOrDefault(oi => oi.RequiresManualFulfillment) != null)
            {
                requiresManualFulfillment = true;
            }

            return requiresManualFulfillment;
        }

        public List<Shipment> Shipments { get; set; }

        public List<dynamic> Returns { get; set; }
    }
}
