using Application.Common;
using Domain.Interfaces;
using Domain.Models.Likes;
using Domain.Models.Matches;
using MediatR;

namespace Application.Commands.Likes;
public class LikeUserCommandHandler
    : IRequestHandler<LikeUserCommand, OperationResult<string>>
{
    private readonly ILikeRepository _likeRepo;
    private readonly IFriendMatchRepository _matchRepo;

    public LikeUserCommandHandler(
        ILikeRepository likeRepo,
        IFriendMatchRepository matchRepo)
    {
        _likeRepo = likeRepo;
        _matchRepo = matchRepo;
    }

    public async Task<OperationResult<string>> Handle(
        LikeUserCommand request,
        CancellationToken cancellationToken)
    {
     
        if (request.FromUserId == request.ToUserId)
            return OperationResult<string>
                .Failure("Cannot like yourself");

   
        if (!await _likeRepo.ExistsAsync(request.FromUserId, request.ToUserId))
        {
            await _likeRepo.AddAsync(new Like
            {
                FromUserId = request.FromUserId,
                ToUserId = request.ToUserId
            });
        }

        var reverseExists = await _likeRepo.ExistsAsync(
            request.ToUserId,
            request.FromUserId);

        if (reverseExists)
        {
            var matchExists = await _matchRepo.ExistsAsync(
                request.FromUserId,
                request.ToUserId);

            if (!matchExists)
            {
                await _matchRepo.AddAsync(new FriendMatch
                {
                    User1Id = request.FromUserId,
                    User2Id = request.ToUserId
                });

                return OperationResult<string>
                    .Success("It's a match!");
            }
        }

        return OperationResult<string>
            .Success("Like sent");
    }
}