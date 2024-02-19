using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class CommunityImageData : RepositoryBase<CommunityImage, CommuPointDbContext>, ICommunityImageData
    {
        public CommunityImageData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
