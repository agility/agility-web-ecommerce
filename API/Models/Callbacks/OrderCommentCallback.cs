using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models.Callbacks
{
    public class OrderCommentCallback
    {
        public bool QAMode { get; set; }
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string WebsiteName { get; set; }
        public string OrderComment { get; set; }
    }
}
