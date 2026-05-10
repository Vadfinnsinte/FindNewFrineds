using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Matches
{
    public class FriendMatch
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid User1Id { get; set; }
        public User User1 { get; set; }

        public Guid User2Id { get; set; }
        public User User2 { get; set; }
    }
}
