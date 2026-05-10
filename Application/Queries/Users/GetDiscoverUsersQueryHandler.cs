using Application.Common;
using Application.Dtos.User;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Users
{
    public class GetDiscoverUsersQueryHandler
        : IRequestHandler<GetDiscoverUsersQuery, OperationResult<List<UserCardDTO>>>
    {
        private readonly IUserRepository _userRepo;
        private readonly ILikeRepository _likeRepo;
        private readonly IFriendMatchRepository _matchRepo;

        public GetDiscoverUsersQueryHandler(
            IUserRepository userRepo,
            ILikeRepository likeRepo,
            IFriendMatchRepository matchRepo)
        {
            _userRepo = userRepo;
            _likeRepo = likeRepo;
            _matchRepo = matchRepo;
        }

        public async Task<OperationResult<List<UserCardDTO>>> Handle(
      GetDiscoverUsersQuery request,
      CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetDiscoverUsersAsync(request.UserId);

            var result = users.Select(user => new UserCardDTO
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Age = user.Age,
                Bio = user.Bio,
                City = user.City,
                Interests = user.Interests
            }).ToList();

            return OperationResult<List<UserCardDTO>>
                .Success(result);
        }
    }
}