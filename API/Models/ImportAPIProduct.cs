using Agility.Web.eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class ImportAPIProduct
    {
        public string languageCode { get; set; }
        public Product EcomData { get; set; }
        public ExpandoObject AgilityData { get; set; }
    }
}
