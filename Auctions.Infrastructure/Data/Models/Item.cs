namespace Auctions.Infrastructure.Data.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
