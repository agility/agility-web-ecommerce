using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class StoreCreditListing
    {        
        public int TotalCount { get; set; }

        public List<StoreCredit> Items { get; set; }

        public int? Counts { get; set; }
    }        
}
