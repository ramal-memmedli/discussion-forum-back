using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class AnswerVoteRepository : RepositoryBase<AnswerVote, DebatDbContext>, IAnswerVoteRepository
    {
        public AnswerVoteRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
