using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Listing<T>
    {
        public dynamic Counts = null;
        public int TotalCount = 0;
        public List<T> Items = new List<T>();
    }
}
