using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class ImageData : RepositoryBase<Image, CommuPointDbContext>, IImageData
    {
        public ImageData(CommuPointDbContext context) : base(context)
        {

        }
    }
}
