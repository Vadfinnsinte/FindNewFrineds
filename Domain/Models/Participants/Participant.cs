using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Events;
using Domain.Models.Users;

namespace Domain.Models.Participants
{
    public class Participant
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public Guid EventId { get; set; }
        public EventEntity Event { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
