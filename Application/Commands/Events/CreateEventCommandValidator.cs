using Application.Commands.Event;

using FluentValidation;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Dto.City)
            .NotEmpty().WithMessage("City is required");

        RuleFor(x => x.Dto.Adress)
            .NotEmpty().WithMessage("Adress is required");
        RuleFor(x => x.Dto.Category)
            .NotEmpty()
            .WithMessage("Category is required");

        RuleFor(x => x.Dto.DateOfEvent)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Event date must be in the future");
    }
}