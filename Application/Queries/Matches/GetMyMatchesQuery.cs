using Application.Common;
using Application.Dtos.Matches;
using MediatR;

namespace Application.Queries.Matches
{
    public class GetMyMatchesQuery
        : IRequest<OperationResult<List<FriendMatchDto>>>
    {
        public Guid UserId { get; set; }
    }
}