using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class TerminalOrder: ModelBase
    {
        public int TerminalOrderID { get; set; }
        public int OrderID { get; set; }
        public int TerminalID { get; set; }
        public int TerminalLocationID { get; set; }
        public int TerminalUserID { get; set; }

        //virtual
        public TerminalLocation TerminalLocation { get; set; }
        public TerminalUser TerminalUser { get; set; }
    }
}
