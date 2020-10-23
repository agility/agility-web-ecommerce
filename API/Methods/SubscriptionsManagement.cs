using Agility.Web.eCommerce.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API
{
    partial class AgilityeCommerceService
    {
        public Subscription GetSubscription(int subscriptionID = 0, string subscriptionNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    subscriptionNumber = subscriptionNumber,
                    subscriptionID = subscriptionID
                };


                var response = client.SyncPostJson("/json/SubscriptionService/Get", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Subscription> res = JsonConvert.DeserializeObject<JsonResponse<Subscription>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public int CreateOrUpdateSubscription(Subscription subscription)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    subscriptionJSON = JsonConvert.SerializeObject(subscription)
                };


                var response = client.SyncPostJson("/json/SubscriptionService/Upsert", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<int> res = JsonConvert.DeserializeObject<JsonResponse<int>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public Listing<SubscriptionInterval> ListIntervalTypes()
        {
            using (var client = CreateHttpClient())
            {

                var response = client.SyncGet("/json/SubscriptionService/ListIntervalTypes");

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Listing<SubscriptionInterval>> res = JsonConvert.DeserializeObject<JsonResponse<Listing<SubscriptionInterval>>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

    }
}
