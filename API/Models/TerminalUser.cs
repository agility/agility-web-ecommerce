using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class TerminalUser : ModelBase
    {
        public int TerminalUserID { get; set; }
        public string DisplayName { get; set; }
        public string Login { get; set; }

        public string SetPassword { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public int? SetAccessCode { get; set; }

        [JsonIgnore]
        public int? AccessCode { get; set; }

        public List<int> TerminalLocationIDs = new List<int>();

        [JsonIgnore]
        public string TerminalLocationIDStr
        {
            get
            {
                return string.Join<int>(",", TerminalLocationIDs);
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    TerminalLocationIDs = new List<int>();
                }
                else
                {
                    TerminalLocationIDs = new List<int>(
                        value.Split(',').Select(i => Convert.ToInt32(i)));
                }
            }
        }

    }
}
