using Application.Commands.User;
using Application.Commands.User.Register;
using FluentValidation;

public class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Dto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Dto.Password)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.Dto.Fullname)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(x => x.Dto.Age)
            .GreaterThan(17);

        RuleFor(x => x.Dto.City)
            .NotEmpty();

        RuleFor(x => x.Dto.Interests)
            .NotEmpty();
    }
}