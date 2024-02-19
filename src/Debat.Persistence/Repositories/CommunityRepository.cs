using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class CommunityRepository : RepositoryBase<Community, DebatDbContext>, ICommunityRepository
    {
        public CommunityRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
