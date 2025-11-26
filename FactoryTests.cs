using Delivery.Factories;
using Xunit;

namespace Delivery.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void StandardFactory_CreatesOrderNotExpress()
        {
            var f = new StandardOrderFactory();
            var o = f.CreateOrder("Лев");
            Assert.False(o.IsExpress);
        }

        [Fact]
        public void ExpressFactory_CreatesExpressOrder()
        {
            var f = new ExpressOrderFactory();
            var o = f.CreateOrder("Маша");
            Assert.True(o.IsExpress);
        }
    }
}
