using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.DTOs
{
    public record CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public record CategoryDto(Guid Id);
    }
}
