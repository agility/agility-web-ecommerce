using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public enum OrderListState
    {
        RecycleBin = -1,
        All = 1, //ALL STATUSES
        Draft = 2, //DRAFT = 0
        Submitted = 3, //SUBMITTED = 1, PAYMENT PROCESSED = 2
        Shipped = 4, //SHIPPED = 4, SHIPMENT PENDING = 19, SHIPMENT CREATED = 20
        Completed = 5, //COMPLETE = 5, ALTERNATE DELIVERY = 21
        Abandoned = 6, //ABANDONED = 6
        Cancelled = 7, //CANCELLING = 7, CANCEL COMPLETE = 9
        Returns = 8, //RETURNING = 10, RETURN COMPLETE = 12
        Refunds = 9, //REFUNDING = 13, REFUND COMPLETE = 15
        Errored = 10, //PAYMENT FAILED = 3, SHIPMENT FAILED = 16, CANCEL FAILED = 8, RETURN FAILED = 11, REFUND FAILED = 14
        Fulfillment = 11, //PENDING FULFILLMENT = 18
        Pickup = 12 //PENDING PICKUP = 17
    }
}


