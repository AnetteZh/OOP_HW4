using System;
using Delivery.Core;

namespace Delivery.Factories
{
    public class StandardOrderFactory : IOrderFactory
    {
        public Order CreateOrder(string customerName)
        {
            return new Order(Guid.NewGuid().ToString(), customerName);
        }
    }
}
