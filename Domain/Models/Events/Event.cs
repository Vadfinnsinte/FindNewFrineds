using Domain.Models.Participants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Events
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Adress { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; }
        public string Name { get; set; }
        public string Category { get; set;  }
        public List<Participant> Participants { get; set; } = new();
        public DateTime DateOfEvent { get; set; }
    }
}
