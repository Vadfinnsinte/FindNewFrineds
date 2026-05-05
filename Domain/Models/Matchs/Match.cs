using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Matchs
{
    internal class Match
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public Guid User1 { get; set; }
        public Guid User2 { get; set; }
    }
}
