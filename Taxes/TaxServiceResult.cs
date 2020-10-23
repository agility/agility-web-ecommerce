using Newtonsoft.Json;

namespace Agility.Web.eCommerce.Taxes
{
    public class TaxServiceResult
    {
        public long ValueMinorUnits { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public object Custom { get; set; }
    }
}
