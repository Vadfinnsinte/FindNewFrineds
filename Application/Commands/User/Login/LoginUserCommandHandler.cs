using Application.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

using Domain.Interfaces;
using MediatR;
using Application.Commands.User.Login;

public class LoginCommandHandler
        : IRequestHandler<LoginUserCommand, OperationResult<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwt;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwt)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwt = jwt;
    }

    public async Task<OperationResult<LoginResponse>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
        {
            return OperationResult<LoginResponse>
                .Failure("Invalid credentials");
        }

        var valid = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash);

        if (!valid)
        {
            return OperationResult<LoginResponse>
                .Failure("Invalid credentials");
        }

        var token = _jwt.GenerateToken(user);

        var response = new LoginResponse
        {
            Token = token
        };

        return OperationResult<LoginResponse>
            .Success(response);
    }
}