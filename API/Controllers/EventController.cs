using Application.Commands.Event;
using Application.Dtos.Event;
using Application.Dtos.Events;
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
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _mediator.Send(new GetAllEventsQuery());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEvent(Guid id, EditEventDTO dto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var command = new EditEventCommand
            {
                EventId = id,
                Dto = dto,
                UserId = Guid.Parse(userIdString),
                IsAdmin = User.IsInRole("Admin")
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}