using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class BookmarkRepository : RepositoryBase<UserBookmark, DebatDbContext>, IBookmarkRepository
    {
        public BookmarkRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
