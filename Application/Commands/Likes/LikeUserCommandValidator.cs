using FluentValidation;


namespace Application.Commands.Likes;
public class LikeUserCommandValidator
    : AbstractValidator<LikeUserCommand>
{
    public LikeUserCommandValidator()
    {
        RuleFor(x => x.FromUserId)
            .NotEmpty();

        RuleFor(x => x.ToUserId)
            .NotEmpty()
            .NotEqual(x => x.FromUserId);
    }
}