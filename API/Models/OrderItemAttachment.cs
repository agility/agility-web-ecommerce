using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public class OrderItemAttachment
    {
        public string OriginalFilename { get; set; }
        public string GUID { get; set; }
        public long Size { get; set; }
        public string UploadedBy { get; set; }
        public int OrderItemID { get; set; }
    }
}
