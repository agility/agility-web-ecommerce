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
        public List<int> GetProductIDs()
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {

                };

                var response = client.SyncPostJson("/json/ProductService/ProductIDs", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<List<int>> res = JsonConvert.DeserializeObject<JsonResponse<List<int>>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }


        public Product GetProduct(int productID, bool includeAdditionalJSON = false)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productID = productID,
                    includeAdditionalJSON = includeAdditionalJSON
                };

                var response = client.SyncPostJson("/json/ProductService/Get", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Product> res = JsonConvert.DeserializeObject<JsonResponse<Product>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public ImportAPIProduct GetProductWithAgilityData(
            int productID, 
            string languageCode, 
            bool variant = false,
            bool includeAdditionalJSON = false)
        {
            return this
                .GetProductWithAgilityDataAsync(
                    productID, 
                    languageCode, 
                    variant, 
                    includeAdditionalJSON)
                .Result;
        }

        public async Task<ImportAPIProduct> GetProductWithAgilityDataAsync(
            int productID, 
            string languageCode, 
            bool variant = false,
            bool includeAdditionalJSON = false)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productID = productID,
                    languageCode = languageCode,
                    variant = variant,
                    includeAdditionalJSON = includeAdditionalJSON
                };

                var response = client.SyncPostJson("/json/ProductService/GetWithAgilityData", postObj);

                string str = await response.Content.ReadAsStringAsync();

                JsonResponse<ImportAPIProduct> res = JsonConvert.DeserializeObject<JsonResponse<ImportAPIProduct>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public ImportResponse CreateProduct(ImportAPIProduct product)
        {
            using (var client = CreateHttpClient())
            {

                var postObj = new
                {
                    product = product
                };

                var response = client.SyncPostJson("/json/ProductService/CreateProduct", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<ImportResponse> res = JsonConvert.DeserializeObject<JsonResponse<ImportResponse>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public ImportResponse UpdateProduct(ImportAPIProduct product)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    product = product
                };

                var response = client.SyncPostJson("/json/ProductService/UpdateProduct", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<ImportResponse> res = JsonConvert.DeserializeObject<JsonResponse<ImportResponse>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public ImportResponse UpdateProductVariant(ImportAPIProduct product)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    product = product
                };

                var response = client.SyncPostJson("/json/ProductService/UpdateProductVariant", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<ImportResponse> res = JsonConvert.DeserializeObject<JsonResponse<ImportResponse>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public int PublishProduct(int productID, string languageCode)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productID = productID,
                    languageCode = languageCode,
                    publish = true
                };

                var response = client.SyncPostJson("/json/ProductService/PublishProduct", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<int> res = JsonConvert.DeserializeObject<JsonResponse<int>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }

        public ImportResponse CreateProductVariant(ImportAPIProduct product)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    product = product
                };

                var response = client.SyncPostJson("/json/ProductService/CreateProductVariant", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<ImportResponse> res = JsonConvert.DeserializeObject<JsonResponse<ImportResponse>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }


        public Listing<dynamic> SearchProducts(string languageCode, string columnStr, string filter, bool showDeleted = false, int pageSize = 50, int rowOffset = 0, string sort = "Title")
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    languageCode = languageCode,
                    columnStr = columnStr,
                    filter = filter,
                    showDeleted = showDeleted,
                    pageSize = pageSize,
                    rowOffset = rowOffset,
                    sort = sort,

                };
                var response = client.SyncPostJson("/json/ProductService/SearchProducts", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<Listing<dynamic>> res = JsonConvert.DeserializeObject<JsonResponse<Listing<dynamic>>>(str);
                CheckResponse(res);

                return res.ResponseData;
            }
        }


        public void DeleteProduct(int productID, string languageCode)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productID = productID,
                    languageCode = languageCode
                };

                var response = client.SyncPostJson("/json/ProductService/DeleteProduct", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<dynamic> res = JsonConvert.DeserializeObject<JsonResponse<dynamic>>(str);
                CheckResponse(res);

            }
        }

        public void DeleteProductVariant(int productVariantID, string languageCode)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productVariantID = productVariantID,
                    languageCode = languageCode
                };

                var response = client.SyncPostJson("/json/ProductService/DeleteProductVariant", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<dynamic> res = JsonConvert.DeserializeObject<JsonResponse<dynamic>>(str);
                CheckResponse(res);

            }
        }

        public void DeleteProductVariantMeasure(int productVariantMeasure)
        {
            using (var client = CreateHttpClient())
            {
                var postObj = new
                {
                    productVariantMeasureID = productVariantMeasure,
                };

                var response = client.SyncPostJson("/json/ProductService/DeleteProductVariantMeasure", postObj);

                string str = response.Content.ReadAsStringAsync().Result;

                JsonResponse<dynamic> res = JsonConvert.DeserializeObject<JsonResponse<dynamic>>(str);
                CheckResponse(res);

            }
        }

    }

}
