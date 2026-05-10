using Domain.Interfaces;
using Domain.Models.Events;
using Domain.Models.Participants;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Participants
{
    public class ParticipantRepository
        : IParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(
            Guid eventId,
            Guid userId)
        {
            return await _context.Participants
                .AnyAsync(p =>
                    p.EventId == eventId &&
                    p.UserId == userId);
        }

        public async Task AddAsync(Participant participant)
        {
            await _context.Participants.AddAsync(participant);

            await _context.SaveChangesAsync();
        }
        public async Task<List<EventEntity>> GetUserEventsAsync(Guid userId)
        {
            return await _context.Participants
                .Where(p => p.UserId == userId)
                .Select(p => p.Event)
                .ToListAsync();
        }
        public async Task<Participant?> GetAsync(Guid eventId,Guid userId)
        {
            return await _context.Participants
                .FirstOrDefaultAsync(p =>
                    p.EventId == eventId &&
                    p.UserId == userId);
        }

        public async Task DeleteAsync(Participant participant)
        {
            _context.Participants.Remove(participant);

            await _context.SaveChangesAsync();
        }
    }
}