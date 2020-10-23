using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderItemFulfillment : ModelBase
    {
        public int OrderItemFulfillmentID { get; set; }
        public int OrderFulfillmentID { get; set; }
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

    }
}
