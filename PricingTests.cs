using Delivery.Core;
using Delivery.Pricing;
using Delivery.Utils;
using Xunit;

namespace Delivery.Tests
{
    public class PricingTests
    {
        [Fact]
        public void PricingService_AppliesStrategies_InOrder()
        {
            var ps = new PricingService();
            ps.AddStrategy(new BasePriceStrategy());
            ps.AddStrategy(new DiscountStrategy(new Money(10m), 0.1m)); // 10% over 10
            ps.AddStrategy(new TaxStrategy(0.1m)); // 10% tax
            ps.AddStrategy(new DeliveryFeeStrategy(new Money(2m), new Money(5m), 20m)); // fee logic

            var order = new Order("o1", "Test");
            order.AddItem(new MenuItem("a", "A", new Money(6m)), 1); // 6
            order.AddItem(new MenuItem("b", "B", new Money(5m)), 1); // 5 => 11 base
            order.IsExpress = false;

            var total = ps.CalculateTotal(order);
            // base 11 -> discount 10% = 9.9 -> tax 10% = 10.89 -> delivery fee (threshold 20) +2 => 12.89
            Assert.Equal(12.89m, total.Amount);
        }
    }
}
