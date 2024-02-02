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
    [Route("api/users")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{username}")]
        public async ValueTask<Results<NotFound, Ok<GetUserDetailsDto>>> GetUserByUsername([FromRoute] string username, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var user = await auctionsDbContext.Users
                .Where(user => user.Username.Equals(username))
                .Select(user => new GetUserDetailsDto(user))
                .FirstOrDefaultAsync(cancellationToken);
            return user == null ? TypedResults.NotFound() : TypedResults.Ok(user);
        }
        [HttpPost]
        public async ValueTask<Results<BadRequest, Ok<GetUserDetailsDto>>> CreateUser([FromBody] CreateUserDto createUserDto, AuctionsDbContext auctionsDbContext, CancellationToken cancellationToken)
        {
            var existingUser = await auctionsDbContext.Users
                .Where(user => user.Username.Equals(createUserDto.Username) || user.Email.Equals(createUserDto.Email))
                .FirstOrDefaultAsync(cancellationToken);

            if (existingUser != null)
            {
                return TypedResults.BadRequest();
            }

            var user = new User();
            user.Id = Guid.NewGuid();
            user.Email = createUserDto.Email;
            user.Username = createUserDto.Username;

            await auctionsDbContext.AddAsync<User>(user, cancellationToken);
            await auctionsDbContext.SaveChangesAsync(cancellationToken);

            return TypedResults.Ok(new GetUserDetailsDto(user));
        }
    }
}
