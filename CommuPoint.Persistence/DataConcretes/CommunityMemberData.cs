using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class CommunityMemberData : RepositoryBase<CommunityMember, CommuPointDbContext>, ICommunityMemberData
    {
        public CommunityMemberData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
