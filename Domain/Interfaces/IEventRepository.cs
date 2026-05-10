using Domain.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        Task AddAsync(EventEntity eventEntity);
        Task<EventEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(EventEntity eventEntity);
        Task<List<EventEntity>> GetAllAsync();
        Task DeleteAsync(EventEntity eventEntity);
    }
}
