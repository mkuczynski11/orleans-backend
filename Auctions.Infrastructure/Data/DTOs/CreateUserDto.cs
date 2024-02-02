using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.DTOs
{
    public record CreateUserDto
    {
        public string Email {  get; set; }
        public string Username { get; set; }
    }
}
