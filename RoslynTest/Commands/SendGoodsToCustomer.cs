using System;

namespace RoslynTest.Commands
{
    public sealed class SendGoodsToCustomer : Command
    {
        public Guid OrderId { get; private set; }

        public string DeliveryAddress { get; private set; }

        public string CustomerName { get; private set; }
    }
}
