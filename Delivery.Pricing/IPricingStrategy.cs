using Delivery.Core;
using Delivery.Utils;

namespace Delivery.Pricing
{
    public interface IPricingStrategy
    {
        Money Apply(Order order, Money current);
    }
}
