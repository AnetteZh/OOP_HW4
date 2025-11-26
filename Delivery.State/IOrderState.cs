using Delivery.Core;

namespace Delivery.State
{
    public interface IOrderState
    {
        string Name { get; }
        void Next(Order order);
        void Cancel(Order order);
    }
}
