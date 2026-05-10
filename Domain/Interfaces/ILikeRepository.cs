using Domain.Models.Likes;


namespace Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task<bool> ExistsAsync(Guid fromUserId, Guid toUserId);
        Task AddAsync(Like like);
    }
}
