using System.Collections.Generic;
using Delivery.Core;
using Delivery.Utils;

namespace Delivery.Pricing
{
    // комбинируем стратегии
    public class PricingService
    {
        private readonly List<IPricingStrategy> _strategies = new();

        public void AddStrategy(IPricingStrategy s) => _strategies.Add(s);

        public Money CalculateTotal(Order order)
        {
            Money current = Money.Zero;
            foreach (var s in _strategies)
            {
                current = s.Apply(order, current);
            }
            return current;
        }
    }
}
