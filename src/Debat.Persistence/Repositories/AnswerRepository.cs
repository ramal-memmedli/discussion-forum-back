using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer, DebatDbContext>, IAnswerRepository
    {
        public AnswerRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
