using Microsoft.AspNetCore.Identity;
using SlotEase.Application.Interfaces;
using SlotEase.Domain.Entities;


namespace SlotEase.Infrastructure.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<User> _hasher = new();
        public string Hash(string password)
        {
            return _hasher.HashPassword(new User(), password);
        }

        public bool Verify(string password, string passwordHash)
        {
            var result = _hasher.VerifyHashedPassword(new User(), passwordHash, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}
