using Auctions.Infrastructure.Data;
using Auctions.Infrastructure.Data.DTOs;
using Auctions.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Controllers
{
    [Route("api/auctions")]
    [ApiController]
    //[Authorize]
    public class AuctionController : ControllerBase
    {
        private readonly ILogger<AuctionController> _logger;
        public AuctionController(ILogger<AuctionController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async ValueTask<Ok<GetAuctionsDto>> GetAllAuctions(AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var auctions = await auctionsDbContext.Auctions
                .Include(auction => auction.Owner)
                .Include(auction => auction.Item)
                .ThenInclude(item => item.Category)
                .Select(auction => auction)
                .ToListAsync(cancellationToken);
            return TypedResults.Ok(new GetAuctionsDto(auctions));
        }
        [HttpGet("{auctionId}")]
        public async ValueTask<Results<NotFound, Ok<GetAuctionDetailsDto>>> GetAuctionById([FromRoute] Guid auctionId, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var auction = await auctionsDbContext.Auctions
                .Include(auction => auction.Owner)
                .Include(auction => auction.Item)
                .ThenInclude(item => item.Category)
                .Where(auction => auction.Id.Equals(auctionId))
                .Select(auction => new GetAuctionDetailsDto(auction))
                .FirstOrDefaultAsync(cancellationToken);

            return auction == null ? TypedResults.NotFound() : TypedResults.Ok(auction);
                
        }
        [HttpPost]
        public async ValueTask<Results<NotFound, Ok<GetAuctionDetailsDto>>> CreateAuction([FromBody] CreateAuctionDto createAuctionDto, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var user = await auctionsDbContext.Users
                .Where(user => user.Username.Equals(createAuctionDto.Username))
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return TypedResults.NotFound();
            }

            var category = await auctionsDbContext.Categories
                .Where(category => category.Id.Equals(createAuctionDto.Item.Category.Id))
                .FirstOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                return TypedResults.NotFound();
            }

            var item = new Item();
            item.Id = Guid.NewGuid();
            item.Name = createAuctionDto.Item.Name;
            item.Description = createAuctionDto.Item.Description;
            item.Category = category;


            await auctionsDbContext.AddAsync<Item>(item, cancellationToken);

            var auction = new Auction();
            auction.Id = Guid.NewGuid();
            auction.Item = item;
            auction.Owner = user;

            await auctionsDbContext.AddAsync<Auction>(auction, cancellationToken);

            await auctionsDbContext.SaveChangesAsync(cancellationToken);

            return TypedResults.Ok(new GetAuctionDetailsDto(auction));
        }
    }
}
