using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class PrintTemplate : ModelBase
    {
        public int PrintTemplateID { get; set; }
        public string DisplayName { get; set; }
        public string ReferenceName { get; set; }
        /// <summary>
        /// The Output format of the Receipt (pdf or png). This is a reference string.
        /// </summary>
        public string OutputFormat { get; set; }
        public string Description { get; set; }
        public string BaseGraphicURL { get; set; }
        public string LayoutJSON { get; set; }

    }
}
