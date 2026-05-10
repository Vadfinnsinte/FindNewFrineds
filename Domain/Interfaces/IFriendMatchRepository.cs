using Domain.Models.Matches;

namespace Domain.Interfaces
{
    public interface IFriendMatchRepository
    {
        Task<bool> ExistsAsync(Guid user1Id, Guid user2Id);

        Task AddAsync(FriendMatch match);

        Task<List<FriendMatch>> GetUserMatchesAsync(Guid userId);

        Task<FriendMatch?> GetAsync(Guid user1Id, Guid user2Id);

        Task DeleteAsync(FriendMatch match);
    }
}