using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Promotion : ModelBase
    {
        public int PromotionID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CurrencyID { get; set; }
        public int? PercentValue { get; set; }
        public int? DollarValueMinorUnits { get; set; }
        public int? MinPurchaseAmountMinorUnits { get; set; }
        public bool ApplyToWholeOrder { get; set; }
        public bool AllowWithOtherPromotions { get; set; }
        public bool AutoApplyToOrder { get; set; }
        public bool FreeShippingEligible { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? LimitNumUses { get; set; }
        public int? NumUsesPerPeriod { get; set; }
        public int? RecurringPeriodDays { get; set; }
        public int PromotionValueMinorUnits { get; set; }
        public bool IsExcluded { get; set; }

        private List<int> _productIDs = null;
        public List<int> ProductIDs
        {
            get
            {
                if (_productIDs == null) _productIDs = new List<int>();
                return _productIDs;
            }

            set
            {
                _productIDs = value;
            }
        }

        private List<int> _ticketIDs = null;
        public List<int> TicketIDs
        {
            get
            {
                if (_ticketIDs == null) _ticketIDs = new List<int>();
                return _ticketIDs;
            }

            set
            {
                _ticketIDs = value;
            }
        }

    }
}
