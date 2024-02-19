using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class DefaultValueRepository : RepositoryBase<DefaultValue, DebatDbContext>, IDefaultValueRepository
    {
        public DefaultValueRepository(DebatDbContext contex) : base(contex)
        {

        }
    }
}
