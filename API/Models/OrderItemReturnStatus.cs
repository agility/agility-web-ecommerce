using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public enum OrderItemReturnStatus
    {
        Requested = 0,
        AwaitingReview = 1,
        Approved = 2,
        Declined = 3,
        PendingRefund = 4,
        RefundComplete = 5,
        RefundFailed = 6,
        Cancelled = 7
    }
}
