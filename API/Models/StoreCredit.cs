using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class StoreCredit: ModelBase
    {
        public int StoreCreditID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountMinorUnits { get; set; }
        public string Code { get; set; }
        public int? CustomerID { get; set; }
        public int? CurrencyID { get; set; }
        public string ExternalID { get; set; }
        public bool Disabled { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int BalanceMinorUnits { get; set; }
        public string Token { get; set; }
    }
}
