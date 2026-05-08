using Domain.Interfaces;
using Domain.Models.Events;
using Infrastructure.Database;


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
    }
}
