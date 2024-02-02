using Auctions.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.DTOs
{
    public record GetAuctionDetailsDto
    {
        public GetAuctionDetailsDto(Auction auction)
        {
            Id = auction.Id;
            Item = new ItemDto(auction.Item);
            Owner = new GetUserDetailsDto(auction.Owner);
            Bids = auction.AuctionBids.Select(bid => new AuctionBidDto(bid)).ToList();
        }
        public Guid Id { get; }
        public ItemDto Item { get; set; }
        public GetUserDetailsDto Owner { get; set; }
        public List<AuctionBidDto> Bids { get; set; }
    }
}
