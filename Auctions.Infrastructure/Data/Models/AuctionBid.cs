using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Infrastructure.Data.Models
{
    public class AuctionBid
    {
        public Guid Id { get; private set; }
        public Guid AuctionId { get; private set; }
        public Auction Auction { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public int Price {  get; private set; }
        // TODO: date
        // TODO: was winning?
    }
}
