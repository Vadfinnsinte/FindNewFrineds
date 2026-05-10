using Domain.Models.Likes;
using Domain.Models.Matches;
using Domain.Models.Participants;
using Domain.Models.Roles;


namespace Domain.Models.Users;
public class User
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Age { get; set; }

    public string Bio { get; set; }

    public string City { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Fullname { get; set; }

    public bool Lonely { get; set; }

    public string Interests { get; set; }
    public List<Participant> Participants { get; set; } = new();
    public List<FriendMatch> MatchesAsUser1 { get; set; } = new();
    public List<FriendMatch> MatchesAsUser2 { get; set; } = new();
    public ICollection<UserRole> UserRoles { get; set; }
        = new List<UserRole>();
    public List<Like> LikesSent { get; set; } = new();
    public List<Like> LikesReceived { get; set; } = new();
}