using Application.Common;
using MediatR;
namespace Application.Commands.User.Login
{
    public class LoginUserCommand
      : IRequest<OperationResult<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
