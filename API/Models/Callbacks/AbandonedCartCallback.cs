namespace Agility.Web.eCommerce.API.Models.Callbacks
{
    public class AbandonedCartCallback
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public bool QAMode { get; set; }
    }
}
