using Domain.Models.Users;

namespace Domain.Models.Likes
{
    public class Like
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid FromUserId { get; set; }
        public User FromUser { get; set; } = null!;

        public Guid ToUserId { get; set; }
        public User ToUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}