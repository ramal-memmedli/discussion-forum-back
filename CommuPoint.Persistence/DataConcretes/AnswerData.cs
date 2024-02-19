using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class AnswerData : RepositoryBase<Answer, CommuPointDbContext>, IAnswerData
    {
        public AnswerData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
