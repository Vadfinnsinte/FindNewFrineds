using Application.Commands.User.Register;
using Application.Common;
using Application.Dtos.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Roles;
using Domain.Models.Users;
using MediatR;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, OperationResult<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<OperationResult<string>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(request.Dto.Email);

        if (existingUser != null)
        {
            return OperationResult<string>
                .Failure("Email already exists");
        }

        var user = _mapper.Map<User>(request.Dto);

        user.PasswordHash =
            _passwordHasher.Hash(request.Dto.Password);

        user.Roles.Add(new Role
        {
            Name = request.CreateAdmin
                ? "Admin"
                : "User"
        });

        await _userRepository.AddAsync(user);

        return OperationResult<string>
            .Success("User created");
    }
}