using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Observers
{
    public interface IOrderObserver
    {
        void OnOrderUpdated(Order order, string message);
    }
}
