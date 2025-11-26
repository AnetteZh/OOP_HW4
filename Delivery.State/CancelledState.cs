using Delivery.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.State
{
    public class CancelledState : IOrderState
    {
        public string Name => "Отменен";

        public void Next(Order order)
        {
            order.NotifyObservers("Заказ не може быть перемещен, т.к. был отменен");
        }

        public void Cancel(Order order)
        {
            order.NotifyObservers("Заказ уже отменен");
        }
    }
}
