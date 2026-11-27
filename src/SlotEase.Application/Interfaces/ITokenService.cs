using SlotEase.Domain.Entities;

namespace SlotEase.Application.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAtUtc) CreateToken(User user);
}
