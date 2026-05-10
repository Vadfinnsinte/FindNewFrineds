using Application.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Matches.Delete
{
    public class DeleteMatchCommandHandler
        : IRequestHandler<DeleteMatchCommand, OperationResult<string>>
    {
        private readonly IFriendMatchRepository _repo;

        public DeleteMatchCommandHandler(IFriendMatchRepository repo)
        {
            _repo = repo;
        }

        public async Task<OperationResult<string>> Handle(
            DeleteMatchCommand request,
            CancellationToken cancellationToken)
        {
            var match = await _repo.GetAsync(
                request.UserId,
                request.TargetUserId);

            if (match == null)
            {
                return OperationResult<string>
                    .Failure("No match found");
            }

            // säkerhet: bara deltagare får ta bort matchen
            if (match.User1Id != request.UserId &&
                match.User2Id != request.UserId)
            {
                return OperationResult<string>
                    .Failure("Not allowed");
            }

            await _repo.DeleteAsync(match);

            return OperationResult<string>
                .Success("Match removed");
        }
    }
}