using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.Config
{
    public class eCommerceSettings
    {
        public static string Url
        {
            get
            {
                var s = ConfigurationManager.AppSettings["Agility_eComm_URL"];

                if (string.IsNullOrWhiteSpace(s))
                    s = "https://ecommerce.agilitycms.com";

                return s;
            }
        }

        public static string ScriptUrl
        {
            get
            {
                var s = ConfigurationManager.AppSettings["Agility_eComm_ScriptURL"];

                if (string.IsNullOrWhiteSpace(s))
                    s = "https://ecommerce.agilitycms.com/scripts/website/Agility.Ecommerce.API.js";

                return s;
            }
        }

        public static int QAMode
        {
            get
            {
                var s = ConfigurationManager.AppSettings["Agility_eComm_QAMode"] ?? "0";

                int.TryParse(s, out var qaMode);

                return qaMode;
            }
        }

        public static string Hash()
        {
            string websiteName = AgilityContext.WebsiteName;
            string securityKey = Configuration.Settings.CurrentSettings.WebsiteSettings[0].SecurityKey;

            byte[] key = Encoding.UTF8.GetBytes(securityKey);
            byte[] value = Encoding.UTF8.GetBytes($"{securityKey}.{websiteName}");
            var sha = new HMACSHA256(key);

            var hash = sha.ComputeHash(value);

            string hashStr = Base64Encode(hash);

            return hashStr;
        }

        private static string Base64Encode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding
            return output;
        }
    }
}
