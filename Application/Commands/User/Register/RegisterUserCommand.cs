using Application.Common;
using Application.Dtos.User;
using MediatR;

namespace Application.Commands.User.Register
{
    public class RegisterUserCommand
        : IRequest<OperationResult<string>>
    {
        public RegisterUserDTO Dto { get; set; }

        public bool CreateAdmin { get; set; } = false;
    }
}