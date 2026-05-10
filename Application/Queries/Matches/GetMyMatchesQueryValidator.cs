using FluentValidation;

namespace Application.Queries.Matches
{
    public class GetMyMatchesQueryValidator
        : AbstractValidator<GetMyMatchesQuery>
    {
        public GetMyMatchesQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}