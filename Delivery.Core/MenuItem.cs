using Delivery.Utils;

namespace Delivery.Core
{
    public class MenuItem
    {
        public string Id { get; }
        public string Name { get; }
        public Money Price { get; }

        public MenuItem(string id, string name, Money price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
