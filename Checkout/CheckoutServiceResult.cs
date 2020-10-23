using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Checkout
{
    public class CheckoutServiceResult
    {
        public long ShippingValueMinorUnits { get; set; }

        public long TaxValueMinorUnits { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public object Custom { get; set; }
    }
}
