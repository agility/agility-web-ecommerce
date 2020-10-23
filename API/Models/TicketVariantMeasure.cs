using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class TicketVariantMeasure
    {
        public int? TicketVariantMeasureID { get; set; }
        public int TicketID { get; set; }
        public string Sku { get; set; }
        public string Measure { get; set; }
        public string TicketVariantMeasureUnitID { get; set; }
        public string TicketVariantMeasureUnitTitle { get; set; }
        public int PriceMinorUnits { get; set; }
        public string AdditionalJSON { get; set; }
        //computed prices
        public int? SaleAmountMinorUnits { get; set; }
        public int? SalePriceMinorUnits
        {
            get
            {
                if (SaleAmountMinorUnits != null)
                    return PriceMinorUnits - SaleAmountMinorUnits;

                return null;
            }
        }

        public List<AltPrice> AltPrices = new List<AltPrice>();
    }
}
