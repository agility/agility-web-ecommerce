using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models.Callbacks
{
    public class ReturnStatusUpdateCallback
    {
        public bool QAMode { get; set; }
        public int OrderItemReturnID { get; set; }
        public string ReturnNumber { get; set; }
        public string OrderItemReturnStatus { get; set; }
        public string WebsiteName { get; set; }
    }
}
