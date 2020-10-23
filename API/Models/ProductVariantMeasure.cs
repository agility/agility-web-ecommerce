using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class ProductVariantMeasure
    {
        public int? ProductVariantMeasureId { get; set; }
        public int ProductID { get; set; }
        public string Sku { get; set; }
        public string Measure { get; set; }
        public string ProductVariantMeasureUnitID { get; set; }
        public string ProductVariantMeasureUnitTitle { get; set; }
        public int PriceMinorUnits { get; set; }
        public string AdditionalJSON { get; set; }
    }
}
