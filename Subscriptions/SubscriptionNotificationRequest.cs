using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Subscriptions
{
    public class SubscriptionNotificationRequest
    {
        public int SubscriptionID { get; set; }
        public bool IsFirstNotification { get; set; }
    }
}
