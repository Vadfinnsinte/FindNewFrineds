using FluentValidation;

namespace Application.Commands.Events.Delete
{
    public class DeleteEventCommandValidator
        : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(x => x.EventId)
                .NotEmpty()
                .WithMessage("EventId is required");
        }
    }
}