using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public enum ShipmentStatus
    {
        Pending = 1,
        PendingPickup = 2,
        Shipped = 3,
        Delivered = 4,
        Failed = 5,
        OnHold = 6
    }
}
