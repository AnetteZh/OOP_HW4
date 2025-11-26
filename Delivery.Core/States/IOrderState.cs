
namespace Delivery.Core.States
{
    public interface IOrderState
    {
        string Name { get; }
        void Next(Order order);
        void Cancel(Order order);
    }
}
