using Application.Commands.User.Register;
using Application.Commands.User.Login;
using Application.Common.Exceptions;
using Application.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
   
                var result = await _mediator.Send(command);
                return Ok(result);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
        RegisterUserDTO dto)
        {
            var command = new RegisterUserCommand
            {
                Dto = dto
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterUserDTO dto)
        {
            var command = new RegisterUserCommand
            {
                Dto = dto,
                CreateAdmin = true
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
   
}