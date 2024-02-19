using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class CommentRepository : RepositoryBase<Comment, DebatDbContext>, ICommentRepository
    {
        public CommentRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
