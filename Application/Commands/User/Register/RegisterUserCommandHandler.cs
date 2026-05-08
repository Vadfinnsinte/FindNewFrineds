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
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
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


        var roleName = request.CreateAdmin ? "Admin" : "User";

        var role = await _roleRepository.GetByNameAsync(roleName);

        if (role == null)
        {
            return OperationResult<string>
                .Failure("Role not found");
        }

        user.UserRoles.Add(new UserRole
        {
            User = user,
            Role = role
        });

        await _userRepository.AddAsync(user);

        return OperationResult<string>
            .Success("User created");
    }
}