using Agility.Web.eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Agility.Web.eCommerce.API
{
    public partial class AgilityeCommerceService
    {
        private readonly string BaseUri;
        private readonly string AuthHash;

        public AgilityeCommerceService()
        {
            BaseUri = "http://ecommerce.dev.edentity.ca/";/*Config.eCommerceSettings.Url;*/
            AuthHash = Config.eCommerceSettings.Hash();
        }

        public AgilityeCommerceService(string baseUri, string authHash)
        {
            BaseUri = baseUri;
            AuthHash = authHash;
        }

        private string GetAuthHeader()
        {
            return string.Format("Basic {0}", AuthHash);
        }

        private void CheckResponse(IJsonResponse res)
        {
            if (res.IsError)
            {
                throw new ApplicationException(res.ErrorMessage);
            }
        }

        private void CheckResponse(CustomStoredProcedureResult res)
        {
            if (res.IsError)
            {
                throw new ApplicationException($"{res.ErrorMessage}, StackTrace: {res.StackTrace}");
            }
        }

        private void CheckResponse(JsonResponse<TaskEventHandler> res)
        {
            if (res.IsError)
            {
                Agility.Web.Tracing.WebTrace.WriteWarningLine(string.Format("Error in Ecom Service: {0} - Stacktrace:{1}", res.ErrorMessage, res.StackTrace));
                throw new ApplicationException(res.ErrorMessage);
            }
        }


        /// <summary>
        /// Creates a instance of <see cref="eCommerceHttpClient"/> 
        /// using the default HTTP headers.
        /// </summary>
        /// <returns>Returns a new instance of <see cref="eCommerceHttpClient"/>. 
        /// Null, otherwise.</returns>
        private eCommerceHttpClient CreateHttpClient()
        {
            eCommerceHttpClient client = null;

            try
            {
                var headers = new Dictionary<string, string>()
                {
                    { "WebsiteName", "Visit Orlando" },
                    { "Authorization", GetAuthHeader() }
                };

                client = new eCommerceHttpClient(BaseUri, headers);
            }
            catch (Exception)
            {
                client = null;
            }

            return client;
        }


    }
}
