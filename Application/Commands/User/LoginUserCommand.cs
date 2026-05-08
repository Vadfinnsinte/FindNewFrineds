

using MediatR;
namespace Application.Commands.User
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
