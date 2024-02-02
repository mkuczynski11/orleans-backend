using Auctions.Infrastructure.Data;
using Auctions.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async ValueTask<Ok<List<CategoryDto>>> GetAllCategories(AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var categories = await auctionsDbContext.Categories
                .Select(x => new CategoryDto(x.Id, x.Name))
                .ToListAsync(cancellationToken);

            return TypedResults.Ok(categories);
        }
        [HttpGet("{categoryId}")]
        public async ValueTask<Results<NotFound, Ok<CategoryDto>>> GetCategory([FromRoute] Guid categoryId, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var category = await auctionsDbContext.Categories
                .Where(category => category.Id.Equals(categoryId))
                .Select(category => new CategoryDto(category.Id, category.Name))
                .FirstOrDefaultAsync(cancellationToken);

            return category == null ? TypedResults.NotFound() : TypedResults.Ok(category);
        }
        [HttpGet("{categoryId}/auctions")]
        public async ValueTask<Results<NotFound, Ok<GetAuctionsDto>>> GetAuctionsByCategory([FromRoute] Guid categoryId, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var category = await auctionsDbContext.Categories
                .Where(category => category.Id.Equals(categoryId))
                .FirstOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                return TypedResults.NotFound();
            }

            var auctions = await auctionsDbContext.Auctions
                .Include(auction => auction.Owner)
                .Include(auction => auction.Item)
                .ThenInclude(item => item.Category)
                .Where(auction => auction.Item.Category.Equals(category))
                .ToListAsync(cancellationToken);

            return TypedResults.Ok(new GetAuctionsDto(auctions));
        }
    }
}
