

namespace Delivery.Core.States
{
    public class CancelledState : IOrderState
    {
        public string Name => "Отменен";

        public void Next(Order order)
        {
            order.NotifyObservers("Заказ не может быть перемещен, т.к. был отменен");
        }

        public void Cancel(Order order)
        {
            order.NotifyObservers("Заказ уже отменен");
        }
    }
}
