using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.Models
{
    public class Auction
    {
        public Guid Id { get; set; }
        public Item Item { get; set; }
        public User Owner {  get; set; }
        public ICollection<AuctionBid> AuctionBids { get; set; } = new List<AuctionBid>();
    }
}
