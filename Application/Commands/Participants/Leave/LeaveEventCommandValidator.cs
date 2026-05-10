using FluentValidation;

namespace Application.Commands.Participants.Leave
{
    public class LeaveEventCommandValidator
        : AbstractValidator<LeaveEventCommand>
    {
        public LeaveEventCommandValidator()
        {
            RuleFor(x => x.EventId)
                .NotEmpty();
        }
    }
}