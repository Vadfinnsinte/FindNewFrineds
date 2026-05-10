using FluentValidation;

namespace Application.Queries.Users
{
    public class GetDiscoverUsersQueryValidator
        : AbstractValidator<GetDiscoverUsersQuery>
    {
        public GetDiscoverUsersQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}