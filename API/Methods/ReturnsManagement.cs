using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agility.Web.eCommerce.API.Models;
using Newtonsoft.Json;

namespace Agility.Web.eCommerce.API
{
    public partial class AgilityeCommerceService
    {
        public OrderItemReturn UpsertOrderItemReturn(OrderItemReturn orderItemReturn, bool triggerReturnsStatusChangeCallback = true)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    orderItemReturn = orderItemReturn,
                    triggerReturnsStatusChangeCallback = triggerReturnsStatusChangeCallback
                };


                var response = client.SyncPostJson("/json/ReturnsService/Upsert", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<OrderItemReturn> res = JsonConvert.DeserializeObject<JsonResponse<OrderItemReturn>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public OrderItemReturn GetOrderItemReturn(int? orderItemReturnID = null, string returnNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    orderItemReturnID = orderItemReturnID,
                    returnNumber = returnNumber
                };


                var response = client.SyncPostJson("/json/ReturnsService/Get", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<OrderItemReturn> res = JsonConvert.DeserializeObject<JsonResponse<OrderItemReturn>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public List<OrderItemReturn> GetOrderItemReturnsForOrder(int orderID)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    orderID = orderID,
                };


                var response = client.SyncPostJson("/json/ReturnsService/GetForOrder", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<OrderItemReturn>> res = JsonConvert.DeserializeObject<JsonResponse<List<OrderItemReturn>>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public void RefundOrderItemReturn(int orderItemReturnID)
        {
            using (var client = CreateHttpClient())
            {
                dynamic data = new
                {
                    orderItemReturnID = orderItemReturnID
                };


                var response = client.SyncPostJson("/json/ReturnsService/ProcessRefund", data);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);

            }
        }

    }
}
