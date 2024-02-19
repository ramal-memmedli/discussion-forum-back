using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;

namespace Debat.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, DebatDbContext>, ICategoryRepository
    {
        public CategoryRepository(DebatDbContext context) : base(context)
        {

        }
    }
}
