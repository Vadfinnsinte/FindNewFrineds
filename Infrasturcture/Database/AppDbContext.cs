using Domain.Models.Events;
using Domain.Models.Matches;
using Domain.Models.Messages;
using Domain.Models.Participants;
using Domain.Models.Roles;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<FriendMatch> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Participant>()
                .HasKey(p => new { p.UserId, p.EventId });

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.User)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.EventId);


            modelBuilder.Entity<FriendMatch>()
                .HasOne(m => m.User1)
                .WithMany(u => u.MatchesAsUser1)
                .HasForeignKey(m => m.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendMatch>()
                .HasOne(m => m.User2)
                .WithMany(u => u.MatchesAsUser2)
                .HasForeignKey(m => m.User2Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

         
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Email = "alice@test.com",
                    Fullname = "Alice Andersson",
                    Age = 25,
                    City = "Gothenburg",
                    Bio = "Gillar träning och kaffe",
                    Interests = "Gym, Coffee, Music",
                    Lonely = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEI4hjOuDOPeVr7FfOvbhiJ2RDi3gYzRbtELCqYLi+sH56T0ePP1HPGmYfjjq+LCc3w==",
                    CreatedAt = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Email = "bob@test.com",
                    Fullname = "Bob Svensson",
                    Age = 30,
                    City = "Stockholm",
                    Bio = "Älskar spel och tech",
                    Interests = "Gaming, Tech",
                    Lonely = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEI4hjOuDOPeVr7FfOvbhiJ2RDi3gYzRbtELCqYLi+sH56T0ePP1HPGmYfjjq+LCc3w==",
                    CreatedAt = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}