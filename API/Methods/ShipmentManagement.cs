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

        public List<Shipment> GetShipmentsForOrder(int orderID)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID
                };

                var response = client.SyncPostJson("/json/ShipmentService/GetForOrder", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<Shipment>> res = JsonConvert.DeserializeObject<JsonResponse<List<Shipment>>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public Shipment GetShipment(int shipmentID = -1, string shipmentNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    shipmentID = shipmentID,
                    shipmentNumber = shipmentNumber
                };

                var response = client.SyncPostJson("/json/ShipmentService/Get", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Shipment> res = JsonConvert.DeserializeObject<JsonResponse<Shipment>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public Shipment CreateOrUpdateShipment(Shipment shipment)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    shipment = shipment
                };

                var response = client.SyncPostJson("/json/ShipmentService/CreateOrUpdate", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Shipment> res = JsonConvert.DeserializeObject<JsonResponse<Shipment>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public void DeleteShipment(int shipmentID, string shipmentNumber = null)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    shipmentID = shipmentID,
                    shipmentNumber = shipmentNumber
                };

                var response = client.SyncPostJson("/json/ShipmentService/Delete", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse res = JsonConvert.DeserializeObject<JsonResponse>(str);
                CheckResponse(res);

            }
        }

        public List<string> ListShipmentsByStatus(ShipmentStatus shipmentStatus)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    shipmentStatus = shipmentStatus
                };

                var response = client.SyncPostJson("/json/ShipmentService/ListByStatus", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<string>> res = JsonConvert.DeserializeObject<JsonResponse<List<string>>>(str);
                CheckResponse(res);

                return res.ResponseData;

            }
        }

        public Shipment CreateShipmentFromOrder(int orderID, ShipmentStatus shipmentStatus = ShipmentStatus.Pending)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    shipmentStatus = shipmentStatus
                };

                var response = client.SyncPostJson("/json/ShipmentService/CreateFromOrder", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Shipment> res = JsonConvert.DeserializeObject<JsonResponse<Shipment>>(str);
                CheckResponse(res);

                return res.ResponseData;

            }
        }

    }

}
