using Application.Common;
using Application.Dtos.Matches;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Matches
{
    public class GetMyMatchesQueryHandler
        : IRequestHandler<
            GetMyMatchesQuery,
            OperationResult<List<FriendMatchDto>>>
    {
        private readonly IFriendMatchRepository _repo;

        public GetMyMatchesQueryHandler(
            IFriendMatchRepository repo)
        {
            _repo = repo;
        }

        public async Task<OperationResult<List<FriendMatchDto>>> Handle(
            GetMyMatchesQuery request,
            CancellationToken cancellationToken)
        {
            var matches =
                await _repo.GetUserMatchesAsync(request.UserId);

            var result = matches.Select(m => new FriendMatchDto
            {
                Id = m.Id,
                CreatedAt = m.CreatedAt,
                OtherUserName =
                    m.User1Id == request.UserId
                        ? m.User2.Fullname
                        : m.User1.Fullname
            }).ToList();

            return OperationResult<List<FriendMatchDto>>
                .Success(result);
        }
    }
}