using System;
using Delivery.Core;

namespace Delivery.Factories
{
    public class ExpressOrderFactory : IOrderFactory
    {
        public Order CreateOrder(string customerName)
        {
            var order = new Order(Guid.NewGuid().ToString(), customerName)
            {
                IsExpress = true
            };
            return order;
        }
    }
}
