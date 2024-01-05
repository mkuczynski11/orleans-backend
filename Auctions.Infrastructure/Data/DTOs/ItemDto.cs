using Auctions.Infrastructure.Data.Models;

namespace Auctions.Infrastructure.Data.DTOs;

public record ItemDto
{
    public ItemDto(Item item)
    {
        Id = item.Id;
        Name = item.Name;
        Description = item.Description;
        Category = new CategoryDto(item.Category!.Id, item.Category!.Name);
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public CategoryDto Category { get; }
    public record CategoryDto(Guid Id, string Name);
}
