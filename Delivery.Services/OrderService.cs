using Delivery.Core;
using Delivery.Factories;
using Delivery.Pricing;
using Delivery.Utils;
using Delivery.Core.States;
using Delivery.Core.Decorators;

namespace Delivery.Services
{
    public class OrderService
    {
        private readonly PricingService _pricing;
        private readonly Dictionary<string, Order> _orders = new();

        public OrderService(PricingService pricing)
        {
            _pricing = pricing;
        }

        public Order CreateOrder(IOrderFactory factory, string customerName)
        {
            var order = factory.CreateOrder(customerName);
            _orders[order.Id] = order;
            return order;
        }

        public Order GetOrder(string id)
        {
            if (!_orders.TryGetValue(id, out var order))
                throw new ArgumentException("Заказ не найден");
            return order;
        }

        public void AddItem(string orderId, MenuItem item, int qty)
        {
            var order = GetOrder(orderId);
            order.AddItem(item, qty);
        }

        public Money CalculateTotal(string orderId)
        {
            var order = GetOrder(orderId);

            // применяем стратегии
            Money total = _pricing.CalculateTotal(order);

            // применяем декораторы
            IPriceComponent component = new BasePriceComponent(total);

            if (order.IsExpress)
                component = new ExpressDeliveryDecorator(component, new Money(2.50m));

            if (order.GiftWrap)
                component = new GiftWrapDecorator(component, new Money(1.20m));

            return component.GetPrice();
        }

        public void AdvanceState(string orderId)
        {
            var order = GetOrder(orderId);
            order.NextState();
        }

        public void CancelOrder(string orderId)
        {
            var order = GetOrder(orderId);
            order.Cancel();
        }

        public IEnumerable<Order> GetAllOrders() => _orders.Values;
    }
}
