using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class CommentData : RepositoryBase<Comment, CommuPointDbContext>, ICommentData
    {
        public CommentData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
