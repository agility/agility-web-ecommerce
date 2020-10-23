using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Taxes
{
    /// <summary>
    /// Defines the required properties
    /// to link a ticket with a tax rate.
    /// </summary>
    public interface ITaxableItem
    {
        int TicketID { get; set; }

        ITaxRate TaxRate { get; set; }
    }
}
