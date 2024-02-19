using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryData;

        public CategoryService(ICategoryRepository categoryData)
        {
            _categoryData = categoryData;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = await _categoryData.GetAllAsync();

            if (categories is null)
            {
                throw new NullReferenceException();
            }

            return categories;
        }

        public async Task Create(Category entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _categoryData.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Get(int id)
        {
            Category category = await _categoryData.GetAsync(n => n.Id == id);

            if (category is null)
            {
                throw new NullReferenceException();
            }

            return category;
        }



        public Task<List<Category>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _categoryData.UpdateAsync(entity);
        }
    }
}
