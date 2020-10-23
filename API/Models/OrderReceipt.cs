using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderReceipt
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderLog> OrderLogs { get; set; }
    }
}
