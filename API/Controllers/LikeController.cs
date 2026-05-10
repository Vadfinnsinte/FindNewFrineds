using Application.Commands.Likes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/likes")]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("{toUserId}")]
        public async Task<IActionResult> Like(Guid toUserId)
        {
            var userIdString =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var command = new LikeUserCommand
            {
                FromUserId = Guid.Parse(userIdString),
                ToUserId = toUserId
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}