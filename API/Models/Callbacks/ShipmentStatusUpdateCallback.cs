using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models.Callbacks
{
    public class ShipmentStatusUpdateCallback
    {
        public int ShipmentID { get; set; }
        public string ShipmentNumber { get; set; }
        public string ShipmentStatus { get; set; }
        public bool QAMode { get; set; }
    }
}
