using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderLog
    {
        public int OrderLogID { get; set; }

        public int SubtotalValueMinorUnits { get; internal set; }
        public int TaxAmountMinorUnits { get; set; }
        public int TotalValueMinorUnits { get; internal set; }
        public int TotalPromotionalValueMinorUnits { get; internal set; }
        public int ShippingCostMinorUnits { get; internal set; }

        public int SubTotalDiffMinorUnits { get; internal set; }
        public int TaxDiffMinorUnits { get; set; }
        public int TotalDiffMinorUnits { get; internal set; }
        public int TotalPromotionalDiffMinorUnits { get; internal set; }
        public int ShippingCostDiffMinorUnits { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<TransactionLog> TransactionLogs { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
