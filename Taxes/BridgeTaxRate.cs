using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Taxes
{
    public class BridgeTaxRate : ITaxRate
    {
        public string Title { get; set; } = string.Empty;

        public double Rate { get; set; } = 0.0D;

        public string FinanceKey { get; set; } = string.Empty;
    }
}
