using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class LevelData : RepositoryBase<Level, CommuPointDbContext>, ILevelData
    {
        public LevelData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
