using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Messages
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public string Text { get; set; }
    }
}
