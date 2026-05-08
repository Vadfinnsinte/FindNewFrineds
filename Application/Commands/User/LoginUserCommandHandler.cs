using Application.Commands.User;
using Application.Interfaces;
using Application.Common.Exceptions;

using Domain.Interfaces;
using MediatR;

public class LoginCommandHandler
    : IRequestHandler<LoginUserCommand, LoginResponse>
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

    public async Task<LoginResponse> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new UnauthorizedException("Invalid credentials");

        var valid = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash);

        if (!valid)
            throw new UnauthorizedException("Invalid credentials");

        var token = _jwt.GenerateToken(user);

        return new LoginResponse
        {
            Token = token
        };
    }
}