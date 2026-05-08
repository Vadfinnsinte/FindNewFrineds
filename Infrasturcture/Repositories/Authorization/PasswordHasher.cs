using Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;

namespace Infrastructure.Repositories.Authorization
{

        public class PasswordHasher : IPasswordHasher
        {
            private readonly PasswordHasher<User> _passwordHasher =
                new();

            public string Hash(string password)
            {
                return _passwordHasher.HashPassword(null!, password);
            }

            public bool Verify(string password, string passwordHash)
            {
                var result = _passwordHasher.VerifyHashedPassword(
                    null!,
                    passwordHash,
                    password);

                return result == PasswordVerificationResult.Success;
            }
        }
    
}
