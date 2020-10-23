using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Agility.Web.eCommerce.API
{
    public class JsonResponse<T> : IJsonResponse
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T ResponseData { get; set; }
        public string StackTrace { get; set; }

        public JsonResponse()
        {
            ResponseData = default(T);
        }
        public JsonResponse(T data)
        {
            ResponseData = data;
        }

        public JsonResponse(Exception ex, string message)
        {
            IsError = true;
            ErrorMessage = message;
            SetException(ex);
        }


        public void SetException(Exception ex)
        {
            StackTrace = ex.ToString();
            ErrorMessage = ErrorMessage + " (" + ex.Message + ")";
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }


    public class JsonResponse : IJsonResponse
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public object ResponseData { get; set; }
        public string StackTrace { get; set; }

        public JsonResponse() { }
        public JsonResponse(object data)
        {
            ResponseData = data;
        }

        public JsonResponse(Exception ex, string message)
        {
            IsError = true;
            ErrorMessage = message;
            SetException(ex);
        }


        public void SetException(Exception ex)
        {
            CustomErrorsMode customErrorsMode = CustomErrorsMode.Off;
            try
            {
                CustomErrorsSection customErrorsSection = (CustomErrorsSection)ConfigurationManager.GetSection("system.web/customErrors");
                customErrorsMode = customErrorsSection.Mode;
            } catch {}

            //only output stack trace when if we have custom errors off!
            if (customErrorsMode == CustomErrorsMode.Off)
            {
                StackTrace = ex.ToString();
            }

            ErrorMessage = ErrorMessage + " (" + ex.Message + ")";
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public interface IJsonResponse
    {
        bool IsError { get; set; }
        string ErrorMessage { get; set; }
        string StackTrace { get; set; }

    }
}
