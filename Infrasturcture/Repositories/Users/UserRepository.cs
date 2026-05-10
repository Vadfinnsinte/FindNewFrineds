using Domain.Interfaces;
using Domain.Models.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetDiscoverUsersAsync(Guid userId)
        {
            return await _context.Users
                .Where(u => u.Id != userId)

                .Where(u => !_context.Likes.Any(l =>
                    l.FromUserId == userId &&
                    l.ToUserId == u.Id))

                .Where(u =>
                    !u.MatchesAsUser1.Any(m => m.User2Id == userId) &&
                    !u.MatchesAsUser2.Any(m => m.User1Id == userId))

                .ToListAsync();
        }
    }
}
