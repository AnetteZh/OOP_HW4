using Xunit;
using Delivery.Factories;
using Delivery.Services;
using Delivery.Pricing;
using Delivery.Utils;
using Delivery.Core;

namespace Delivery.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_And_AddItems_Works()
        {
            var pricing = new PricingService();
            pricing.AddStrategy(new BasePriceStrategy());
            var service = new OrderService(pricing);

            var factory = new StandardOrderFactory();
            var order = service.CreateOrder(factory, "Иван");

            var burger = new MenuItem("b1", "Бургер", new Money(5m));
            service.AddItem(order.Id, burger, 2);

            var total = service.CalculateTotal(order.Id);
            Assert.Equal(10m, total.Amount);
        }

        [Fact]
        public void ExpressDecorator_AppliesExtraFee()
        {
            var pricing = new PricingService();
            pricing.AddStrategy(new BasePriceStrategy());
            var service = new OrderService(pricing);

            var factory = new ExpressOrderFactory();
            var order = service.CreateOrder(factory, "Ольга");

            var pizza = new MenuItem("p1", "Пицца", new Money(8m));
            service.AddItem(order.Id, pizza, 1);

            order.GiftWrap = true;

            var total = service.CalculateTotal(order.Id);
            Assert.Equal(11.70m, total.Amount);
        }

        [Fact]
        public void StateTransitions_Work()
        {
            var pricing = new PricingService();
            var service = new OrderService(pricing);

            var order = service.CreateOrder(new StandardOrderFactory(), "Alex");

            Assert.Equal("Готовится", order.State.Name);
            service.AdvanceState(order.Id);
            Assert.Equal("В доставке", order.State.Name);
            service.AdvanceState(order.Id);
            Assert.Equal("Завершен", order.State.Name);
        }
    }
}