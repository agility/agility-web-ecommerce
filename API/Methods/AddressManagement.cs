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
        public Listing<Address> List()
        {
            using (var client = CreateHttpClient())
            {
                var response = client.SyncGet(string.Format("/json/AddressService/List"));

                string str = response.Content.ReadAsStringAsync().Result;
                
                JsonResponse<Listing<Address>> res = JsonConvert.DeserializeObject<JsonResponse<Listing<Address>>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }

        public void UpdateDefaults(int addressID, bool isBillingAddress, bool isShippingAddress)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    addressID = addressID,
                    isBillingAddress = isBillingAddress,
                    isShippingAddress = isShippingAddress
                };

                var response = client.SyncPostJson("/json/AddressService/UpdateDefaults", postObj);
            }
        }

        public int Upsert(string addressJSON)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    addressJSON = addressJSON
                };

                var response = client.SyncPostJson("/json/AddressService/Upsert", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<int> res = JsonConvert.DeserializeObject<JsonResponse<int>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }
    }
}
