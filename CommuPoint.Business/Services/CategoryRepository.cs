using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Application.Services;
using CommuPoint.Core.Domain.Entities;

namespace CommuPoint.Business.Services
{
    public class CategoryRepository : ICategoryService
    {
        private readonly ICategoryData _categoryData;

        public CategoryRepository(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = await _categoryData.GetAllAsync();

            if(categories is null)
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
