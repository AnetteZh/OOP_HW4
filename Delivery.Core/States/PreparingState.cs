
namespace Delivery.Core.States
{
    public class PreparingState : IOrderState
    {
        public string Name => "Готовится";

        public void Next(Order order)
        {
            order.SetState(new DeliveringState());
            order.NotifyObservers("Отдан в доставку");
        }

        public void Cancel(Order order)
        {
            order.SetState(new CancelledState());
            order.NotifyObservers("Приготовление отменено");
        }
    }
}
