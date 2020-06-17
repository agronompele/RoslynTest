using System;

namespace RoslynTest.DomainEvents
{
    public sealed class OrderAccepted : DomainEvent
    {
        public OrderAccepted(Guid orderId, string deliveryAddress)
        {
            OrderId = orderId;
            DeliveryAddress = deliveryAddress;
        }

        public Guid OrderId { get; }

        public string DeliveryAddress { get; }
    }
}
