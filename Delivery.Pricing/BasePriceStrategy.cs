using System;
using Delivery.Core;
using Delivery.Utils;

namespace Delivery.Pricing
{
    public class BasePriceStrategy : IPricingStrategy
    {
        public Money Apply(Order order, Money current)
        {
            return order.GetBaseCost();
        }
    }
}
