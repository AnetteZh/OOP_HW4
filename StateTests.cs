using Delivery.Core;
using Xunit;

namespace Delivery.Tests
{
    public class StateTests
    {
        [Fact]
        public void OrderState_Transitions_Work()
        {
            var order = new Order("s1", "Сергей");
            Assert.Equal("Готовится", order.State.Name);

            order.NextState(); // -> Delivering
            Assert.Equal("В доставке", order.State.Name);

            order.NextState(); // -> Completed
            Assert.Equal("Завершен", order.State.Name);

            // try to Next on Completed - should remain Completed
            order.NextState();
            Assert.Equal("Завершен", order.State.Name);
        }

        [Fact]
        public void CancelFromPreparing_LeadsToCancelled()
        {
            var order = new Order("s2", "Анна");
            order.Cancel();
            Assert.Equal("Отменен", order.State.Name);
        }
    }
}
