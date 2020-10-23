using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class Customer : ModelBase
    {

        public int CustomerID { get; set; }
        public string CustomerKey { get; set; }
        public string ExternalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Notes { get; set; }
        public int? BillingAddressID { get; set; }
        public int? ShippingAddressID { get; set; }
        public bool CommunicationsOptIn { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }


    }
}
