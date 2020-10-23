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

        public StoreCreditListing ListStoreCredit(int customerID, string externalID, string sort, string sortDirection, int rowIndex, int pageSize)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    customerID = customerID,
                    externalID = externalID,
                    sort = sort,
                    sortDirection = sortDirection,
                    rowIndex = rowIndex,
                    pageSize = pageSize
                };

                var response = client.SyncPostJson("/json/StoreCreditService/List", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<StoreCreditListing> res = JsonConvert.DeserializeObject<JsonResponse<StoreCreditListing>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public void DeleteStoreCredit(int storeCreditID)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    storeCreditID = storeCreditID,
                };

                var response = client.SyncPostJson("/json/StoreCreditService/Delete", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);

            }
        }

        public StoreCredit GetStoreCredit(int? storeCreditID = null, int? storeCreditCode = null, string externalID = null)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    storeCreditID = storeCreditID,
                    storeCreditCode = storeCreditCode,
                    externalID = externalID
                };

                var response = client.SyncPostJson("/json/StoreCreditService/Get", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<StoreCredit> res = JsonConvert.DeserializeObject<JsonResponse<StoreCredit>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public void CreateStoreCredit(StoreCredit storeCredit)
        {
            using (var client = CreateHttpClient())
            {
             
                var response = client.SyncPostJson("/json/StoreCreditService/Update", storeCredit);

                string str = response.Content.ReadAsStringAsync().Result;
                
                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);
            }
        }
    }
}
