using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class SubscriptionItem
    {
        
        public int SubscriptionID { get; set; }
        public int SubscriptionItemID { get; set; }
        public int? ProductID { get; set; }
        public int? ProductVariantMeasureID { get; set; }
        public int? TicketID { get; set; }
        public int? TicketVariantMeasureID { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }


        public int PriceMinorUnits { get; set; }
        public int VariantOfProductID { get; set; }
        public string ProductVariantMeasureUnitTitle { get; set; }
        public int VariantOfTicketID { get; set; }
        public string TicketVariantMeasureUnitTitle { get; set; }

        
    }
}
