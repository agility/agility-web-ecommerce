using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public partial class Transaction
    {
        public int TransactionID { get; set; }
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int PaymentProviderID { get; set; }
        public int TotalMinorUnits { get; set; }
        public int AmountRefundedMinorUnits { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public string MaskedCardNumber { get; set; }
        public string CardType { get; set; }
        public bool Success { get; set; }
        public bool FraudReview { get; set; }
        public string ResponseCode { get; set; }
        public bool PreAuthorized { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
