using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class UserImageRepository : RepositoryBase<UserImage, DebatDbContext>, IUserImageRepository
    {
        public UserImageRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
