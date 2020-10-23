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
        public Ticket GetTicket(int ticketID)
        {
            using (var client = CreateHttpClient())
            {
                var response = client.SyncPost(string.Format("/json/TicketService/GetTicket?ticketID={0}", ticketID));

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Ticket> res = JsonConvert.DeserializeObject<JsonResponse<Ticket>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }

        public List<int> GetTicketIDs()
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {

                };

                var response = client.SyncPostJson("/json/TicketService/TicketIDs", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<int>> res = JsonConvert.DeserializeObject<JsonResponse<List<int>>>(str);

                return res.ResponseData;
            }
        }

        public Ticket GetTicketVariant(int ticketID)
        {
            using (var client = CreateHttpClient())
            {
                var response = client.SyncPost(string.Format("/json/TicketService/GetTicketVariant?ticketID={0}", ticketID));

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Ticket> res = JsonConvert.DeserializeObject<JsonResponse<Ticket>>(str);
                CheckResponse(res);
                return res.ResponseData;
            }
        }
    }

}
