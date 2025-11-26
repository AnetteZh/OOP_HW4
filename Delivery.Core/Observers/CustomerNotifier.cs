using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Observers
{
    public class CustomerNotifier : IOrderObserver
    {
        public void OnOrderUpdated(Order order, string message)
        {
            Console.WriteLine($"[Customer] Заказ {order.Id} теперь в состоянии: {order.State.Name}");
        }
    }
}
