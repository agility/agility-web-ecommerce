using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public string SubscriptionNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime NextOrderDate { get; set; }
        public int SubscriptionStatusID { get; set; }
        public int CustomerID { get; set; }
        public int PaymentTypeID { get; set; }
        public int BillingAddressID { get; set; }
        public int ShippingAddressID { get; set; }
        public int SubscriptionIntervalID { get; set; }
        public bool QAMode { get; set; }
        public bool SkipNextInterval { get; set; }
        public int CurrencyID { get; set; }
        public string AdditionalJSON { get; set; }
        public DateTime? PauseStartDate { get; set; }
        public DateTime? PauseEndDate { get; set; }

        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public List<SubscriptionItem> Items { get; set; }
    }
}
