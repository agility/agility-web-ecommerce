using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderItemStatusUpdate
    {
        public int OrderItemID { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
    }
}
