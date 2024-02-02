using Auctions.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.DTOs
{
    public record AuctionBidDto
    {
        public AuctionBidDto(AuctionBid bid)
        {
            Id = bid.Id;
            Auction = new AuctionDto(bid.AuctionId);
            User = new UserDto(bid.User.Id, bid.User.Email, bid.User.Username);
            Price = bid.Price;
        }
        public Guid Id { get; }
        public AuctionDto Auction { get; set;}
        public UserDto User { get; set; }
        public int Price { get; }
        public record AuctionDto(Guid Id);
        public record UserDto(Guid Id, string Email, string Username);
    }
}
