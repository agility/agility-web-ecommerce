using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class SubscriptionInterval : ModelBase
    {
        public int SubscriptionIntervalID { get; set; }
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public int SubscriptionIntervalTypeID { get; set; }
        public int IntervalNum { get; set; }
        public int NotifyDaysBeforeInterval { get; set; }
    }
}
