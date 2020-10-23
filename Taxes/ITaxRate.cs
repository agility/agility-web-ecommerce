using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Taxes
{
    public interface ITaxRate
    {
        string Title { get; set; }

        double Rate { get; set; }

        string FinanceKey { get; set; }
    }
}
