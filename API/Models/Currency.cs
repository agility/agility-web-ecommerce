using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Currency: ModelBase
    {
        public int CurrencyID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Symbol { get; set; }
        public bool IsDefault { get; set; }
        public double PercentFromDefault { get; set; }
    }
}
