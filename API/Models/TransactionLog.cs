using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    
    public class TransactionLog : Transaction
    {
        public int OrderLogID { get; set; }
    }
    
}
