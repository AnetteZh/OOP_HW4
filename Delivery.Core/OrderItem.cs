using Delivery.Utils;

namespace Delivery.Core
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; }
        public int Quantity { get; }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }

        public Money GetCost() => new Money(MenuItem.Price.Amount * Quantity);
    }
}
