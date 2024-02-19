using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class AnswerVoteData : RepositoryBase<AnswerVote, CommuPointDbContext>, IAnswerVoteData
    {
        public AnswerVoteData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
