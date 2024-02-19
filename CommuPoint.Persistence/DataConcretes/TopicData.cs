using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class TopicData : RepositoryBase<Topic, CommuPointDbContext>, ITopicData
    {
        public TopicData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
