using Application.Commands.Matches.Create;
using Application.Commands.Matches.Delete;
using Application.Queries.Matches;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/matches")]
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyMatches()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var result = await _mediator.Send(
                new GetMyMatchesQuery
                {
                    UserId = Guid.Parse(userId)
                });

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpDelete("{matchId}")]
        public async Task<IActionResult> DeleteMatch(Guid matchId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var command = new DeleteMatchCommand
            {
                TargetUserId = matchId,
                UserId = Guid.Parse(userId)
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}