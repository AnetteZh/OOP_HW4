using Delivery.Core;

namespace Delivery.State
{
    public class CompletedState : IOrderState
    {
        public string Name => "Завершен";

        public void Next(Order order)
        {
            order.NotifyObservers("Уже выполнен");
        }

        public void Cancel(Order order)
        {
            order.NotifyObservers("Выполненный заказ нельзя отменить");
        }
    }
}
