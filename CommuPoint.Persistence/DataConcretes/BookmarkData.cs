using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class BookmarkData : RepositoryBase<UserBookmark, CommuPointDbContext>, IBookmarkData
    {
        public BookmarkData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
