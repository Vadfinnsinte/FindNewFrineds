using Domain.Interfaces;
using Domain.Models.Likes;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

public class LikeRepository : ILikeRepository
{
    private readonly AppDbContext _context;

    public LikeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(Guid fromUserId, Guid toUserId)
    {
        return await _context.Likes.AnyAsync(x =>
            x.FromUserId == fromUserId &&
            x.ToUserId == toUserId);
    }

    public async Task AddAsync(Like like)
    {
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();
    }
}