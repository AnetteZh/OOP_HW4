using Delivery.Utils;

namespace Delivery.Core.Decorators
{
    public interface IPriceComponent
    {
        Money GetPrice();
    }
}
