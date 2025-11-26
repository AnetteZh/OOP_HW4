using Delivery.Core;
using Delivery.Core.Observers;
using Xunit;

namespace FoodDelivery.Tests
{
    public class ObserverTests
    {
        private class TestObserver : IOrderObserver
        {
            public bool WasCalled = false;

            public void OnOrderUpdated(Order order, string meassage)
            {
                WasCalled = true;
            }
        }

        [Fact]
        public void Observer_Notified_On_State_Change()
        {
            var order = new Order("s1", "Анна");
            var obs = new TestObserver();
            order.AddObserver(obs);

            order.NextState();

            Assert.True(obs.WasCalled);
        }
    }
}
