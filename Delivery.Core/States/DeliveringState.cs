
namespace Delivery.Core.States
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
            order.SetState(new CancelledState());
            order.NotifyObservers("Доставка отменена");
        }
    }
}
