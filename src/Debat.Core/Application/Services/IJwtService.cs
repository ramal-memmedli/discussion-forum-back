using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface IJwtService
{
    string GenerateToken(AppUser user);
}