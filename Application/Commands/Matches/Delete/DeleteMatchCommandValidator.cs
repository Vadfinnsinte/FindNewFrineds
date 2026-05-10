using FluentValidation;

namespace Application.Commands.Matches.Delete
{
    public class DeleteMatchCommandValidator
        : AbstractValidator<DeleteMatchCommand>
    {
        public DeleteMatchCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.TargetUserId)
                .NotEmpty()
                .NotEqual(x => x.UserId)
                .WithMessage("Invalid target user");
        }
    }
}