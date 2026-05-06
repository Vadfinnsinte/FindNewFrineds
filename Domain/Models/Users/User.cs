using Domain.Models.Participants;
using Domain.Models.Matches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Users;
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Age { get; set; }

    public string Bio { get; set; }

    public string City { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Fullname { get; set; }

    public bool Lonely { get; set; }

    public string Interests { get; set; }
    public List<Participant> Participants { get; set; } = new();
    public List<Match> MatchesAsUser1 { get; set; } = new();
    public List<Match> MatchesAsUser2 { get; set; } = new();
}