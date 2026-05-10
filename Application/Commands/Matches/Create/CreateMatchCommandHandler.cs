using Application.Common;
using Domain.Interfaces;
using Domain.Models.Matches;
using MediatR;

namespace Application.Commands.Matches.Create
{
    public class CreateMatchCommandHandler
        : IRequestHandler<CreateMatchCommand, OperationResult<string>>
    {
        private readonly IFriendMatchRepository _repo;

        public CreateMatchCommandHandler(
            IFriendMatchRepository repo)
        {
            _repo = repo;
        }

        public async Task<OperationResult<string>> Handle(
            CreateMatchCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _repo.ExistsAsync(
                request.UserId,
                request.TargetUserId);

            if (exists)
            {
                return OperationResult<string>
                    .Failure("Match already exists");
            }

            var match = new FriendMatch
            {
                User1Id = request.UserId,
                User2Id = request.TargetUserId
            };

            await _repo.AddAsync(match);

            return OperationResult<string>
                .Success("Match created");
        }
    }
}