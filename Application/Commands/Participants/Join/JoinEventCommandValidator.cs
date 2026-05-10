using FluentValidation;

namespace Application.Commands.Participants.Join
{
    public class JoinEventCommandValidator
        : AbstractValidator<JoinEventCommand>
    {
        public JoinEventCommandValidator()
        {
            RuleFor(x => x.EventId)
                .NotEmpty();
        }
    }
}