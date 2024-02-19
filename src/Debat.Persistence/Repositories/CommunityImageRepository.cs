using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class CommunityImageRepository : RepositoryBase<CommunityImage, DebatDbContext>, ICommunityImageRepository
    {
        public CommunityImageRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
