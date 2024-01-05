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
    [Authorize]
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
            var categories = await auctionsDbContext.Categories.Select(x => new CategoryDto(x.Id, x.Name)).ToListAsync(cancellationToken);
            return TypedResults.Ok(categories);
        }
    }
}
