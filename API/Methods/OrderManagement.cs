using Agility.Web.eCommerce.API.Models;
using Agility.Web.eCommerce.Taxes;
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
        /// <summary>
        /// Gets an Order.
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public Order GetOrder(int orderID = -1, string orderNumber = null, int orderItemID = -1)
        {
            return GetOrderAsync(orderID, orderNumber, orderItemID).Result;
        }

        public async Task<Order> GetOrderAsync(
            int orderID = -1,
            string orderNumber = null,
            int orderItemID = -1)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    orderNumber = orderNumber,
                    orderItemID = orderItemID
                };

                var response = client.SyncPostJson("/json/OrderService/Get", postObj);

                var str = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<JsonResponse<Order>>(str);

                CheckResponse(res);

                return res.ResponseData;
            }
        }

        /// <summary>
        /// Calculate an Order based on the Order being passed-in. Order does not need to be created yet. Order will be set to Draft Status.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order CalculateOrder(Order order, bool isReturnRefund = false)
        {
            //in order for the order to be calculated we need to have this order status set to Draft
            int originalOrderStatusID = order.OrderStatusID;
            order.OrderStatusID = (int)OrderStatus.Draft;

            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderJSON = JsonConvert.SerializeObject(order),
                    isReturnRefund = isReturnRefund
                };

                var response = client.SyncPostJson("/json/OrderService/CalculateOrder", postObj);

                string str = response.Content.ReadAsStringAsync().Result;
                JsonResponse<Order> res = JsonConvert.DeserializeObject<JsonResponse<Order>>(str);
                CheckResponse(res);

                order = res.ResponseData;

                if (order != null)
                {
                    order.OrderStatusID = originalOrderStatusID;
                }

                return order;
            }
        }


        /// <summary>
        /// Updates the AdditionalJSON on the existing Order.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="additionalJSON"></param>
        public void OrderUpdateAdditionalJSON(string orderNumber, string additionalJSON)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderNumber = orderNumber,
                    additionalJSON = additionalJSON
                };

                var response = client.SyncPostJson("/json/OrderService/UpdateAdditionalJSON", postObj);

                string str = response.Content.ReadAsStringAsync().Result;
                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);
            }
        }

        /// <summary>
        /// Sets the tax details at the Order Item level for the Order
        /// </summary>
        /// <param name="tax"></param>
        public void OrderSetTaxesOnOrderItems(Tax tax)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    tax = tax,
                };

                var response = client.SyncPostJson("/json/OrderService/StampTaxesOnOrder", postObj);

                string str = response.Content.ReadAsStringAsync().Result;
                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);
            }
        }

        public Order GetOrderByTrackingCode(string trackingCode)
        {
            using (var client = CreateHttpClient())
            {

                var postObj = new
                {
                    trackingCode = trackingCode,
                };

                var response = client.SyncPostJson("/json/OrderService/GetByTrackingCode", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Order> res = JsonConvert.DeserializeObject<JsonResponse<Order>>(str);
                CheckResponse(res);
                return res.ResponseData;


            }
        }

        public List<Order> ListCompletedOrders(List<int> orderIDs, DateTime? startDate = null, DateTime? endDate = null, int take = 0)
        {
            using (var client = CreateHttpClient())
            {
                string orderIDStr = string.Join<int>(",", orderIDs);



                var postObj = new
                {
                    orderIDs = orderIDStr,
                    startDate = startDate,
                    endDate = endDate,
                    take = take
                };

                var response = client.SyncPostJson("/json/OrderService/ListCompletedOrders", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<Order>> res = JsonConvert.DeserializeObject<JsonResponse<List<Order>>>(str);

                return res.ResponseData;


            }
        }

        public void SetOrderStatus(OrderStatus newOrderStatus, int orderID)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    newOrderStatus = newOrderStatus
                };

                var response = client.SyncPostJson("/json/OrderService/SetOrderStatus", postObj);

                string str = response.Content.ReadAsStringAsync().Result;
                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);
            }
        }

        public List<Order> ListByStatus(OrderStatus orderStatus, int take = 100)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderStatus = orderStatus,
                    take = take
                };

                var response = client.SyncPostJson("/json/OrderService/ListByStatus", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<Order>> res = JsonConvert.DeserializeObject<JsonResponse<List<Order>>>(str);

                return res.ResponseData;
            }
        }

        public Listing<ListingOrder> List(string search, DateTime? startDate, DateTime? endDate, int qaMode, int source = 0, OrderListState listState = OrderListState.All, int? customerID = null, string sort = null, string sortDirection = null, int pageSize = 50, int rowIndex = 0, int? storeCreditID = null, int? subscriptionID = null)
        {

            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    search = search,
                    startDate = startDate,
                    endDate = endDate,
                    qaMode = qaMode,
                    source = source,
                    listState = listState,
                    customerID = customerID,
                    sort = sort,
                    sortDirection = sortDirection,
                    pageSize = pageSize,
                    rowIndex = rowIndex,
                    storeCreditID = storeCreditID,
                    subscriptionID = subscriptionID
                };

                var response = client.SyncPostJson("/json/OrderService/List", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Listing<ListingOrder>> res = JsonConvert.DeserializeObject<JsonResponse<Listing<ListingOrder>>>(str);

                return res.ResponseData;
            }
        }

        public Dictionary<int, Product> GetOrderProducts(int orderID = -1, string orderNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    orderNumber = orderNumber
                };

                var response = client.SyncPostJson("/json/OrderService/GetOrderProducts", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Dictionary<int, Product>> res = JsonConvert.DeserializeObject<JsonResponse<Dictionary<int, Product>>>(str);

                return res.ResponseData;
            }
        }

        public async Task<Dictionary<int, Product>> GetOrderProductsAsync(
            int orderID = -1,
            string orderNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    orderNumber = orderNumber
                };

                var response = client.SyncPostJson("/json/OrderService/GetOrderProducts", postObj);

                string str = await response.Content.ReadAsStringAsync();

                JsonResponse<Dictionary<int, Product>> res = JsonConvert.DeserializeObject<JsonResponse<Dictionary<int, Product>>>(str);

                return res.ResponseData;
            }
        }

        public List<OrderItemAttachment> GetOrderAttachments(int orderID)
        {
            List<OrderItemAttachment> result = new List<OrderItemAttachment>();

            using (var client = CreateHttpClient())
            {
                var blobListingResponse = client.SyncPost(string.Format("/json/OrderService/ListOrderAttachments/?orderID={0}", orderID));

                string str = blobListingResponse.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrWhiteSpace(str))
                {
                    JsonResponse<List<OrderItemAttachment>> blobRes = JsonConvert.DeserializeObject<JsonResponse<List<OrderItemAttachment>>>(str);

                    CheckResponse(blobRes);

                    result = blobRes.ResponseData;
                }
            }

            return result;
        }

        public string GetVoucherUrl(int orderID)
        {
            var result = string.Empty;

            using (var client = CreateHttpClient())
            {
                var blobListingResponse = client.SyncPost(string.Format("/json/OrderService/GetVoucherUrl/?orderID={0}", orderID));

                string str = blobListingResponse.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var blobRes = JsonConvert.DeserializeObject<JsonResponse<string>>(str);

                    CheckResponse(blobRes);

                    result = blobRes.ResponseData;
                }
            }

            return result;
        }

        public byte[] DownloadVoucher(int orderID, out string uniqueID)
        {
            byte[] voucherContent = new byte[] { };
            uniqueID = "";
            try
            {
                var voucherUrl = GetVoucherUrl(orderID);

                string[] urlParts = voucherUrl.Split('/');
                if (urlParts.Length > 6)
                {
                    uniqueID = urlParts[5];
                }

                if (!string.IsNullOrWhiteSpace(voucherUrl))
                {
                    using (var client = CreateHttpClient())
                    {
                        var bytes = client.GetByteArrayAsync(voucherUrl).Result;

                        return bytes;
                    }
                }
            }
            catch (Exception)
            {
                voucherContent = new byte[] { };
            }

            return voucherContent;
        }

        public List<Transaction> GetTransactionsForOrder(int orderID)
        {
            using (var client = CreateHttpClient())
            {
                var response = client.SyncPost(string.Format("/json/OrderService/GetTransactionsForOrder?orderID={0}", orderID));

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<Transaction>> res = JsonConvert.DeserializeObject<JsonResponse<List<Transaction>>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }

        public byte[] DownloadOrderAttachment(string filename)
        {
            using (var client = CreateHttpClient())
            {
                var bytes = client.GetByteArrayAsync($"/json/OrderService/GetOrderAttachment/?guid={filename}").Result;
                return bytes;
            }
        }

        public List<OrderFulfillment> GetOrderFulfillments(int orderID, string orderNumber)
        {
            using (var client = CreateHttpClient())
            {
                var response = client.SyncPost(string.Format("/json/OrderService/GetOrderFulFillments?orderID={0}&orderNumber={1}", orderID, orderNumber));

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<OrderFulfillment>> res = JsonConvert.DeserializeObject<JsonResponse<List<OrderFulfillment>>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }


        /// <summary>
        /// Updates trackingnumber, shippeddate and estimateddeliverydate of order with ordernumber passed in.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="trackingNumber"></param>
        /// <param name="shippedDate"></param>
        /// <param name="estimatedDeliveryDate"></param>
        /// <returns></returns>
        public void UpdateTrackingInfo(
            string orderNumber,
            string trackingNumber,
            DateTime? shippedDate,
            DateTime? estimatedDeliveryDate,
            string trackingUrl)
        {
            using (var client = CreateHttpClient())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@orderNumber", orderNumber);
                parameters.Add("@trackingNumber", trackingNumber);
                parameters.Add("@shippedDate", shippedDate.HasValue ? shippedDate.Value.ToString("yyyy-MM-dd") : null);
                parameters.Add("@estimatedDeliveryDate", estimatedDeliveryDate.HasValue ? estimatedDeliveryDate.Value.ToString("yyyy-MM-dd") : null);
                parameters.Add("@trackingUrl", trackingUrl);

                object postData = new
                {
                    procedureName = "CUSTOM_UpdateTrackingInfo",
                    parameters = parameters
                };

                var response = client.SyncPostJson("/json/CustomDataService/ExecuteProcedure", postData);

                string strResult = response.Content.ReadAsStringAsync().Result;
                var resObj = JsonConvert.DeserializeObject<CustomStoredProcedureResult>(strResult);

                CheckResponse(resObj);
            }
        }

        public void SetOrderItemStatuses(string orderNumber, List<OrderItemStatusUpdate> orderItemStatusUpdates)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderNumber = orderNumber,
                    orderItemsStatusUpdates = orderItemStatusUpdates
                };

                var response = client.SyncPostJson("/json/OrderService/SetOrderItemStatuses", postObj);

                string strResult = response.Content.ReadAsStringAsync().Result;
                var resObj = JsonConvert.DeserializeObject<JsonResponse>(strResult);

                CheckResponse(resObj); ;
            }
        }

        public OrderReceipt GetOrderReceipt(string orderNumber)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderNumber = orderNumber
                };

                var response = client.SyncPostJson("/json/OrderService/GetOrderReceipt", postObj);

                string strResult = response.Content.ReadAsStringAsync().Result;
                var resObj = JsonConvert.DeserializeObject<JsonResponse<OrderReceipt>>(strResult);

                CheckResponse(resObj);

                return resObj.ResponseData;
            }
        }

    }
}
