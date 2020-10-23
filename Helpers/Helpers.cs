using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Agility.Web.eCommerce.Config;

namespace Agility.Web.eCommerce
{
    public static class Helpers
    {
        public static IHtmlString eCommerceSettingsJSON(this HtmlHelper helper)
        {

            var settings = new
            {
                Url = eCommerceSettings.Url,
                LanguageCode = AgilityContext.LanguageCode,
                WebsiteName = AgilityContext.WebsiteName,
                ScriptUrl = eCommerceSettings.ScriptUrl,
                QAMode = eCommerceSettings.QAMode,
                Hash = eCommerceSettings.Hash()
            };

            //HACK: write out JSON using only single quotes
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.QuoteChar = '\'';

                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(writer, settings);
            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}
