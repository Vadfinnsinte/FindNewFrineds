using FluentValidation;

namespace Application.Commands.Matches.Create
{
    public class CreateMatchCommandValidator
        : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.TargetUserId)
                .NotEmpty();

            RuleFor(x => x.TargetUserId)
                .NotEmpty()
                .NotEqual(x => x.UserId)
                .WithMessage("You cannot match yourself");
        }
    }
}