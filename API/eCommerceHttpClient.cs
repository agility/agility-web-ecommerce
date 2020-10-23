using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Agility.Web.eCommerce.API
{
    public class eCommerceHttpClient : HttpClient
    {
        public StringContent PostData { get; set; }

        public eCommerceHttpClient(
            string baseAddress,
            Dictionary<string, string> requestHeaders = null) : this(new TimeSpan(0, 0, 90), baseAddress, requestHeaders)
        {

        }

        public eCommerceHttpClient(
            TimeSpan timeout,
            string baseAddress,
            Dictionary<string, string> requestHeaders = null)
        {
            this.Timeout = timeout;
            this.BaseAddress = new Uri(baseAddress);

            if (requestHeaders != null)
            {
                foreach (KeyValuePair<string, string> header in requestHeaders)
                    this.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public eCommerceHttpClient(
            string baseAddress,
            HttpClientHandler httpClientHandler,
            Dictionary<string, string> requestHeaders = null) : base(httpClientHandler)
        {
            this.Timeout = new TimeSpan(0, 0, 90);
            this.BaseAddress = new Uri(baseAddress);

            if (requestHeaders != null)
            {
                foreach (KeyValuePair<string, string> header in requestHeaders)
                    this.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void SetPostDataJson(object postData)
        {
            if (postData != null)
                this.PostData = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
        }

        public void SetPostData(string postDataStr, Encoding encoding, string contentType)
        {
            if (!string.IsNullOrWhiteSpace(postDataStr))
            {
                this.PostData = new StringContent(postDataStr, encoding, contentType);
            }
        }

        public HttpResponseMessage SyncGet(string url)
        {
            return this.GetAsync(url).Result;
        }

        public HttpResponseMessage SyncPostJson(string url, object postData)
        {
            Agility.Web.Tracing.WebTrace.WriteWarningLine(string.Format("Ecom Service {0} - {1}", url, postData));

            this.SetPostDataJson(postData);
            return this.PostAsync(url, this.PostData).Result;
        }

        public HttpResponseMessage SyncPost(string url)
        {
            return this.PostAsync(url, this.PostData).Result;
        }

        public HttpResponseMessage SyncPost(string url, string postDataStr, Encoding encoding, string contentType)
        {
            this.SetPostData(postDataStr, encoding, contentType);
            return this.PostAsync(url, this.PostData).Result;
        }

    }
}
