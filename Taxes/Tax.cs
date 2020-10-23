using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Taxes
{
    public class Tax
    {
        /// <summary>
        /// The ID of the corresponding Order
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// The total tax amount to be charged on the order
        /// </summary>
        public long TaxAmountMinorUnits { get; set; }

        /// <summary>
        /// The List of OrderItems with their tax info
        /// </summary>
        public IList<TaxItem> TaxItems { get; set; } = new List<TaxItem>();

        /// <summary>
        /// The description of the tax applied to the whole Order
        /// </summary>
        public string TaxDescription { get; set; }
        
        public IList<TaxItem> OrderItems { get; set; } = new List<TaxItem>();
        
        public TaxCustom Custom { get; set; } = new TaxCustom();
    }
}