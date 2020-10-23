using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class ListingOrder
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public int OrderStatusID { get; set; }
        public string OrderStatus { get; set; }
        public int ShippingCostMinorUnits { get; set; }
        public string ShippingDescription { get; set; }
        public int TaxAmountMinorUnits { get; set; }
        public int TotalPromotionalValueMinorUnits { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int TotalValueMinorUnits { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyAbbreviation { get; set; }
        public string TerminalLocationName { get; set; }
        public int CurrencyID { get; set; }
        public int SubscriptionID { get; set; }
        public int TotalCount { get; set; }
        public string TerminalUsername { get; set; }

        public bool TransactionFraudReview { get; set; }


    }
}
