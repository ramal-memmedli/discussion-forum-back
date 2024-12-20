using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface ILevelService : IBaseService<Level>
{
    Task UpgradeUserLevel(AppUser user);
}