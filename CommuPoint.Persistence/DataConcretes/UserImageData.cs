using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class UserImageData : RepositoryBase<UserImage, CommuPointDbContext>, IUserImageData
    {
        public UserImageData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
