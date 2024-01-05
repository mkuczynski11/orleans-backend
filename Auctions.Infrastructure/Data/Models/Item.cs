namespace Auctions.Infrastructure.Data.Models
{
    public class Item
    {
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public Category Category { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
