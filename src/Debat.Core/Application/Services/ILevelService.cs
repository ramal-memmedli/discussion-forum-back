using Debat.Core.Domain.Entities;
using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Application.Services;

public interface ILevelService : IBaseService<Level>
{
    Task UpgradeUserLevel(AppUser user);
}