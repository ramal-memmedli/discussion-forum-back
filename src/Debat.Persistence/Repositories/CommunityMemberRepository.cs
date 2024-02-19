using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class CommunityMemberRepository : RepositoryBase<CommunityMember, DebatDbContext>, ICommunityMemberRepository
    {
        public CommunityMemberRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
