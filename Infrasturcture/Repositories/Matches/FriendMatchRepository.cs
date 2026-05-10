using Domain.Interfaces;
using Domain.Models.Matches;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Matches
{
    public class FriendMatchRepository
        : IFriendMatchRepository
    {
        private readonly AppDbContext _context;

        public FriendMatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(
            Guid user1Id,
            Guid user2Id)
        {
            return await _context.Matches.AnyAsync(m =>
                (m.User1Id == user1Id && m.User2Id == user2Id) ||
                (m.User1Id == user2Id && m.User2Id == user1Id));
        }

        public async Task AddAsync(FriendMatch match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendMatch>> GetUserMatchesAsync(Guid userId)
        {
            return await _context.Matches
                .Include(m => m.User1)
                .Include(m => m.User2)
                .Where(m =>
                    m.User1Id == userId ||
                    m.User2Id == userId)
                .ToListAsync();
        }

        public async Task<FriendMatch?> GetAsync(
            Guid user1Id,
            Guid user2Id)
        {
            return await _context.Matches.FirstOrDefaultAsync(m =>
                (m.User1Id == user1Id && m.User2Id == user2Id) ||
                (m.User1Id == user2Id && m.User2Id == user1Id));
        }

        public async Task DeleteAsync(FriendMatch match)
        {
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
        }
    }
}