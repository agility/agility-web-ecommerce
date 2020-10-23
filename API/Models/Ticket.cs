using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agility.Web.eCommerce.Taxes;

namespace Agility.Web.eCommerce.API.Models
{
    public class Ticket : ModelBase, ITaxable
    {

        public int TaxableID { get; set; }
        public int? VariantOfTicketID { get; set; }
        public string ExternalID { get; set; }
        public string Sku { get; set; }
        public int? PriceMinorUnits { get; set; }
        //computed prices
        public int? SaleAmountMinorUnits { get; set; }
        public int? SalePriceMinorUnits
        {
            get
            {
                if (PriceMinorUnits != null && SaleAmountMinorUnits != null)
                    return PriceMinorUnits - SaleAmountMinorUnits;

                return null;
            }
        }
        public int? CurrencyID { get; set; }

        public bool RequiresManualFulfillment { get; set; }
        public bool IsWeb { get; set; }
        public bool IsPOS { get; set; }

        public int? EventSessionID { get; set; }

        public IList<Ticket> Variants { get; set; }
        public IList<TicketVariantMeasure> VariantMeasures { get; set; }

        public string PrintTemplateIDs { get; set; }

        public ITaxRate TaxRate
        {
            get; set;
        }

        public List<PrintTemplate> PrintTemplates = new List<PrintTemplate>();
    }
}
