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

        public T ExecCustomStoredProcedure<T> (string procedureName, Dictionary<string, object> parameters)
        {
            using (var client = CreateHttpClient())
            {

                object postData = new
                {
                    procedureName = procedureName,
                    parameters = parameters
                };

                var response = client.SyncPostJson("/json/CustomDataService/ExecuteProcedure", postData);

                string strResult = response.Content.ReadAsStringAsync().Result;
                CustomStoredProcedureResult ecomRespObj = JsonConvert.DeserializeObject<CustomStoredProcedureResult>(strResult);

                CheckResponse(ecomRespObj);

                T resObj = ecomRespObj.ResponseData.Results.ToObject<T>();

                return resObj;
            }
        }

    }
}
