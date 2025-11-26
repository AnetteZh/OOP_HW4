using System;
using System.Collections.Generic;
using Delivery.Core.Observers;
using Delivery.Core.States;
using Delivery.Utils;

namespace Delivery.Core
{
    public class Order
    {
        public string Id { get; }
        public string CustomerName { get; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

        private IOrderState _state;
        public IOrderState State => _state;

        // для паттерна Observer
        private readonly List<IOrderObserver> _observers = new();

        public bool IsExpress { get; set; } = false;
        public bool GiftWrap { get; set; } = false;

        public Order(string id, string customerName)
        {
            Id = id;
            CustomerName = customerName;
            _state = new PreparingState();
        }

        public void AddItem(MenuItem menuItem, int qty)
        {
            if (qty <= 0) throw new ArgumentException("Количество должно быть > 0");
            _items.Add(new OrderItem(menuItem, qty));
            NotifyObservers($"Добавлена новая позиция {menuItem} в количестве {qty}");
        }

        public Money GetBaseCost()
        {
            Money total = Money.Zero;
            foreach (var it in _items) total += it.GetCost();
            return total;
        }

        public void SetState(IOrderState newState)
        {
            _state = newState;
            NotifyObservers("Статус заказа изменен");
        }

        public void NextState() => _state.Next(this);
        public void Cancel() => _state.Cancel(this);

        public void AddObserver(IOrderObserver observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
        }

        public void RemoveObserver(IOrderObserver observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var o in _observers)
            {
                o.OnOrderUpdated(this, message);
            }
        }
    }
}
