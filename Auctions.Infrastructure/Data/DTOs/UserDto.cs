using Auctions.Infrastructure.Data.Models;

namespace Auctions.Infrastructure.Data.DTOs;

public record UserDto
{
    public UserDto(User user)
    {
        Id = user.Id;
        Email = user.Email;
        Username = user.Username;
        Items = user.Items.Select(item =>
            new ItemDto(item.Id, item.Name)).ToList();

    }
    public Guid Id { get; }
    public string Email { get; }
    public string Username { get; }
    public List<ItemDto> Items { get; set; }
    public record ItemDto(Guid Id, string Name);
}