using Delivery.Core;

namespace Delivery.Factories
{
    public interface IOrderFactory
    {
        Order CreateOrder(string customerName);
    }
}
