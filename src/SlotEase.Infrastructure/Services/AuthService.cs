using Microsoft.EntityFrameworkCore;
using SlotEase.Application.DTOs.Auth;
using SlotEase.Application.Exceptions;
using SlotEase.Application.Interfaces;
using SlotEase.Domain.Entities;
using SlotEase.Domain.Enums;
using SlotEase.Infrastructure.Persistence;


namespace SlotEase.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(AppDbContext db, IPasswordHasher passwordHasher)
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();
            var exists = await _db.Users.AnyAsync(u => u.Email == email);
            if (exists)
            {
                throw new ConflictException("An account with this email already exists.");
            }
            var user = new User
            {
                FullName = dto.FullName.Trim(),
                Email = email,
                PasswordHash = _passwordHasher.Hash(dto.Password),
                Role = UserRole.Patient
            };
            _db.Add(user);
            await _db.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }
    }
}
