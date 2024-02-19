using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class CommunityData : RepositoryBase<Community, CommuPointDbContext>, ICommunityData
    {
        public CommunityData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
