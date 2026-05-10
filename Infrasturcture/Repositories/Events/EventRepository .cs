using Domain.Interfaces;
using Domain.Models.Events;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Repositories.Events
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EventEntity eventEntity)
        {
            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<EventEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task UpdateAsync(EventEntity entity)
        {
            _context.Events.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<EventEntity>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }
        public async Task DeleteAsync(EventEntity eventEntity)
        {
            _context.Events.Remove(eventEntity);

            await _context.SaveChangesAsync();
        }
    }
}
