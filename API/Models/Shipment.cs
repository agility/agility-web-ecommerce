using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Shipment : ModelBase
    {
        public int ShipmentID { get; set; }
        public string ShipmentNumber { get; set; }
        public int ShipmentStatusID { get; set; }
        public string ShippingDescription { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? ShippingEstimatedArrivalDate { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingURL { get; set; }
        public string Notes { get; set; }
        public string AdditionalJSON { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
