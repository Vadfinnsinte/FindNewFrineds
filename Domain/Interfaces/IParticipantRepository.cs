using Domain.Models.Events;
using Domain.Models.Participants;

namespace Domain.Interfaces
{
    public interface IParticipantRepository
    {
        Task<bool> ExistsAsync(Guid eventId, Guid userId);

        Task AddAsync(Participant participant);
        Task<List<EventEntity>> GetUserEventsAsync(Guid userId);
        Task<Participant?> GetAsync(Guid eventId, Guid userId);
        Task DeleteAsync(Participant participant);
    }
}