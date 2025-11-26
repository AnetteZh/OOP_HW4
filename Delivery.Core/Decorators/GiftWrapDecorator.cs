using Delivery.Utils;

namespace Delivery.Core.Decorators
{
    public class GiftWrapDecorator : PriceDecorator
    {
        private readonly Money _wrapFee;
        public GiftWrapDecorator(IPriceComponent component, Money wrapFee) : base(component) => _wrapFee = wrapFee;
        public override Money GetPrice() => new Money(_component.GetPrice().Amount + _wrapFee.Amount);
    }
}
