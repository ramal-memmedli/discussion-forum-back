using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class ImageRepository : RepositoryBase<Image, DebatDbContext>, IImageRepository
    {
        public ImageRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
