using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderItemReturn : ModelBase
    {
        public int OrderItemReturnID { get; set; }
        public string ReturnNumber { get; set; }
        public int RestockingFeeMinorUnits { get; set; }
        public int RestockingFeePercentValue { get; set; }
        public bool UsePercentValue { get; set; }
        public int OrderItemID { get; set; }
        public int OrderItemShipmentID { get; set; }
        public int ShipmentID { get; set; }
        public int? RefundedOrderItemID { get; set; }
        public int Quantity { get; set; }
        public int ReturnStatusID { get; set; }
        public string Notes { get; set; }
        public string ProductDescription { get; set; }
        public int CurrencyID { get; set; }
        public string AdditionalJSON { get; set; }
        public int ReasonTypeID { get; set; }
        public string ReasonDescription { get; set; }
    }
}
