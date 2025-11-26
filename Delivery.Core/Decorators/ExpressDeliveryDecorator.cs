using Delivery.Utils;

namespace Delivery.Core.Decorators
{
    public class ExpressDeliveryDecorator : PriceDecorator
    {
        private readonly Money _extra;
        public ExpressDeliveryDecorator(IPriceComponent component, Money extra) : base(component) => _extra = extra;
        public override Money GetPrice() => new Money(_component.GetPrice().Amount + _extra.Amount);
    }
}