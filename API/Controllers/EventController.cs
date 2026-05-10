using Application.Commands.Events.Create;
using Application.Commands.Events.Delete;
using Application.Commands.Participants.Join;
using Application.Commands.Participants.Leave;
using Application.Dtos.Events;
using Application.Queries.Events;
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
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var userIdString =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var command = new DeleteEventCommand
            {
                EventId = id,
                UserId = Guid.Parse(userIdString),
                IsAdmin = User.IsInRole("Admin")
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        //Participant
        [Authorize]
        [HttpPost("{id}/join")]
        public async Task<IActionResult> JoinEvent(Guid id)
        {
            var userIdString =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var command = new JoinEventCommand
            {
                EventId = id,
                UserId = Guid.Parse(userIdString)
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [Authorize]
        [HttpGet("my-events")]
        public async Task<IActionResult> GetMyEvents()
        {
            var userIdString =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var query = new GetMyEventsQuery
            {
                UserId = Guid.Parse(userIdString)
            };

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [Authorize]
        [HttpDelete("{id}/leave")]
        public async Task<IActionResult> LeaveEvent(Guid id)
        {
            var userIdString =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null)
                return Unauthorized();

            var command = new LeaveEventCommand
            {
                EventId = id,
                UserId = Guid.Parse(userIdString)
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}