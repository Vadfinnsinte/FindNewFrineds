using Application.Commands.Event;
using Application.Dtos.Event;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AddEventDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var command = new CreateEventCommand
            {
                Dto = dto,
                CreatedBy = Guid.Parse(userId!)
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}