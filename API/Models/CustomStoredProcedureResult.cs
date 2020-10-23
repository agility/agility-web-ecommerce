using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class CustomStoredProcedureResult
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public bool IsManagementException { get; set; }
        public string StackTrace { get; set; }

        public CustomStoredProcedureResult() { }

        public CustomStoredProcedureResultResponseData ResponseData { get; set; }
    }

    public class CustomStoredProcedureResultResponseData
    {
        public string ProcedureName { get; set; }

        /// <summary>
        /// Parameters passed in to the proc
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        public Newtonsoft.Json.Linq.JArray Results { get; set; }

        public CustomStoredProcedureResultResponseData() { }
    }
}
