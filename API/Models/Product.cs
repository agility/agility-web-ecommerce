using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Product : ModelBase
    {
        public int ProductID { get; set; }
        public int? VariantOfProductID { get; set; }
        public string ExternalID { get; set; }
        public string Sku { get; set; }
        public int? PriceMinorUnits { get; set; }
        public int? CurrencyID { get; set; }
        public int? WeightGrams { get; set; }
        public int? HeightMM { get; set; }
        public int? WidthMM { get; set; }
        public int? LengthMM { get; set; }
        public string AdditionalJSON { get; set; }

        public List<Product> Variants { get; set; }
        public List<ProductVariantMeasure> VariantMeasures { get; set; }

    }
}
