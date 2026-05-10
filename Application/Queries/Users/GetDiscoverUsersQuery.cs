using Application.Common;
using Application.Dtos.User;
using MediatR;

namespace Application.Queries.Users
{
    public class GetDiscoverUsersQuery
        : IRequest<OperationResult<List<UserCardDTO>>>
    {
        public Guid UserId { get; set; }
    }
}