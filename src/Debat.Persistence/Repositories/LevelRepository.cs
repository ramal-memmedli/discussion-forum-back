using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class LevelRepository : RepositoryBase<Level, DebatDbContext>, ILevelRepository
    {
        public LevelRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
