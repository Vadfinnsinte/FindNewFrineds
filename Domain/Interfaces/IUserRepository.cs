using Domain.Models.Users;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<List<User>> GetDiscoverUsersAsync(Guid userId);
    }
}
