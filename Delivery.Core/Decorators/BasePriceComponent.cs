using Delivery.Utils;

namespace Delivery.Core.Decorators
{
    public class BasePriceComponent : IPriceComponent
    {
        private readonly Money _basePrice;
        public BasePriceComponent(Money basePrice) => _basePrice = basePrice;
        public Money GetPrice() => _basePrice;
    }
}
