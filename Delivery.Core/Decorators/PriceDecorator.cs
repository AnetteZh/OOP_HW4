using Delivery.Utils;

namespace Delivery.Core.Decorators
{
    public abstract class PriceDecorator : IPriceComponent
    {
        protected readonly IPriceComponent _component;
        protected PriceDecorator(IPriceComponent component) => _component = component;
        public abstract Money GetPrice();
    }
}
