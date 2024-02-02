using Auctions.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.DTOs
{
    public record GetAuctionsDto
    {
        public GetAuctionsDto(List<Auction> auctions)
        {
            Auctions = auctions.Select(auction => new AuctionDto(auction.Id, auction.Owner.Username, auction.Item.Name, auction.Item.Category.Name)).ToList();
        }
        public List<AuctionDto> Auctions { get; set; }
        public record AuctionDto(Guid Id, string Owner, String ItemName, string CategoryName);
    }
}
