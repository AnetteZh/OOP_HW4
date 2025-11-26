
namespace Delivery.Core.Observers
{
    public class AnalyticsNotifier : IOrderObserver
    {
        public void OnOrderUpdated(Order order, string message)
        {
            Console.WriteLine($"[Analytics] Логируем изменение состояния заказа {order.Id} -> {order.State.Name}");
        }
    }
}
