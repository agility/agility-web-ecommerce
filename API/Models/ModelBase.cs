using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public abstract class ModelBase
    {
        [JsonIgnore]
        internal int TotalCount { get; set; }
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public int ModifiedBy { get; set; }
        public bool Deleted { get; set; }
    }
}
