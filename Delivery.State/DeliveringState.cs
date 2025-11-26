using Delivery.Core;

namespace Delivery.State
{
    public class DeliveringState : IOrderState
    {
        public string Name => "В доставке";

        public void Next(Order order)
        {
            order.SetState(new CompletedState());
            order.NotifyObservers("Перемещен в завершенные заказы");
        }

        public void Cancel(Order order)
        {
            // Допустим, можно отменить пока в доставке — переводим в Cancelled
            order.SetState(new CancelledState());
            order.NotifyObservers("Доставка отменена");
        }
    }
}
