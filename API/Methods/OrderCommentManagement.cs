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
        public int InsertOrderComment(int orderID, string comment)
        {
            //in order for the order to be calculated we need to have this order status set to Draft

            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    orderID = orderID,
                    comment = comment
                };

                var response = client.SyncPostJson("/json/OrderCommentService/Insert", postObj);

                string str = response.Content.ReadAsStringAsync().Result;
                JsonResponse<int> res = JsonConvert.DeserializeObject<JsonResponse<int>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }
    }
}
