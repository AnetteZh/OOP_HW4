using Delivery.Core;
using Delivery.Utils;

namespace Delivery.Pricing
{
    public class DiscountStrategy : IPricingStrategy
    {
        private readonly Money _threshold;
        private readonly decimal _discountPercent;

        public DiscountStrategy(Money threshold, decimal discountPercent)
        {
            _threshold = threshold;
            _discountPercent = discountPercent;
        }

        public Money Apply(Order order, Money current)
        {
            if (current.Amount >= _threshold.Amount)
            {
                var discount = new Money(current.Amount * _discountPercent);
                return new Money(current.Amount - discount.Amount);
            }
            return current;
        }
    }
}
