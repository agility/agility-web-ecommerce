using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agility.Web.eCommerce.API.Models
{
    public enum OrderStatus
    {


        //DRAFTS
        Draft = 0,

        //SUBMITTED
        Submitted = 1,
        PaymentProcessed = 2,
        PaymentFailed = 3,

        //SHIPPED
        ShipmentPending = 19, //NEW: Need a state in between PendingFulfillment & Shipped
        ShipmentCreated = 20, //NEW: Need a state in between ShipmentPending & ShipmentCreated
        ShipmentFailed = 16,
        Shipped = 4,

        //COMPLETED
        Complete = 5,
        AlternateDelivery = 21, //NEW: Need a state where an order is being manually delivered and will not necessarily get a Complete state

        //ABANDONED
        Abandoned = 6,

        //CANCELLED
        Cancelling = 7,
        CancelFailed = 8,
        CancelComplete = 9,

        //RETURNS
        Returning = 10,
        ReturnFailed = 11,
        ReturnComplete = 12,

        //REFUNDS
        Refunding = 13,
        RefundFailed = 14,
        RefundComplete = 15,

        //PICKUP
        PendingPickup = 17,

        //FULFILLMENT
        PendingFulfillment = 18


    }
}
