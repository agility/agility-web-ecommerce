using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Subscriptions
{
    public class SubscriptionNotificationResult
    {
        public string Description { get; set; }
        public int ValueMinorUnits { get; set; }
        public string ErrorMessage { get; set; }
        public bool NotImplemented { get; set; }
    }
}
