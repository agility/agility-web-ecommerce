using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderFulfillment : ModelBase
    {
        public int OrderFulfillmentID { get; set; }
        public int OrderID { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
        public int? TerminalUserID { get; set; }
        public string TerminalUserName { get; set; }
        public string SignatureURL { get; set; }
        public string SignatureName { get; set; }

        /// <summary>
        /// THIS LIST IS ONLY POPULATED ON GET - FOR UPDATES - THEY MUST BE DONE INDIVIDUALLY!
        /// </summary>
        public List<OrderItemFulfillment> ItemFulfillments = new List<OrderItemFulfillment>();

    }
}
