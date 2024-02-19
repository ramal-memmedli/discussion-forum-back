using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class TopicRepository : RepositoryBase<Topic, DebatDbContext>, ITopicRepository
    {
        public TopicRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
