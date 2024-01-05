namespace Auctions.Infrastructure.Data.Models
{
    public class User
    {
        public User(string email, string username)
        {
            Email = email;
            Username = username;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public ICollection<Item> Items { get; private set; } = new List<Item>();
    }
}
