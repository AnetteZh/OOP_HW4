using Delivery.Core;
using Delivery.Utils;

namespace Delivery.Pricing
{
    public class DeliveryFeeStrategy : IPricingStrategy
    {
        private readonly Money _standardFee;
        private readonly Money _expressFee;
        private readonly decimal _freeDeliveryThreshold;

        public DeliveryFeeStrategy(Money standardFee, Money expressFee, decimal freeDeliveryThreshold)
        {
            _standardFee = standardFee;
            _expressFee = expressFee;
            _freeDeliveryThreshold = freeDeliveryThreshold;
        }

        public Money Apply(Order order, Money current)
        {
            var baseAmount = current.Amount;
            Money fee = _standardFee;
            if (order.IsExpress) fee = _expressFee;
            if (baseAmount >= _freeDeliveryThreshold) fee = Money.Zero;
            return new Money(current.Amount + fee.Amount);
        }
    }
}
