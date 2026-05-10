using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Matches
{
    public class FriendMatchDto
    {
        public Guid Id { get; set; }

        public string OtherUserName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
