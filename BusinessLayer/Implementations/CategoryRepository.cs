using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
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

        public Task Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<List<Category>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
