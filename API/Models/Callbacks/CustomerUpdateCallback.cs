using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models.Callbacks
{
    public class CustomerUpdateCallback
    {
        public bool QAMode { get; set; }
        public int CustomerID { get; set; }
        public string Action { get; set; }
        public string WebsiteName { get; set; }

    }
}
