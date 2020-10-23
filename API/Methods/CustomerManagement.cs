using Agility.Web.eCommerce.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API
{
    public partial class AgilityeCommerceService
    {
        public Customer GetCustomer(int customerID = -1)
        {
            using (var client = CreateHttpClient())
            {

                var postObj = new
                {
                    customerID = customerID,
                };
                var response = client.SyncGet(string.Format("/json/CustomerService/Get?customerID={0}", customerID));
                //var response = client.SyncPostJon("/json/CustomerPOS/Get", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Customer> res = JsonConvert.DeserializeObject<JsonResponse<Customer>>(str);
                CheckResponse(res);
                return res.ResponseData;


            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (var client = CreateHttpClient())
            {

                var postObj = new
                {
                    customerJson = JsonConvert.SerializeObject(customer),
                };
                var response = client.SyncPostJson("/json/CustomerService/Update", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Customer> res = JsonConvert.DeserializeObject<JsonResponse<Customer>>(str);
                CheckResponse(res);
                return res.ResponseData;


            }
        }
    }
}
