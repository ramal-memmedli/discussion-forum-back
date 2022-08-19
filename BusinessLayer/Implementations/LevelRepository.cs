using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class LevelRepository : ILevelService
    {
        private readonly ILevelData _levelData;

        public LevelRepository(ILevelData levelData)
        {
            _levelData = levelData;
        }
        public async Task<Level> Get(int id)
        {
            Level level = await _levelData.GetAsync(n => n.Id == id);

            if(level is null)
            {
                throw new NullReferenceException();
            }

            return level;
        }


        public Task Create(Level entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<List<Level>> GetAll()
        {
            List<Level> levels = await _levelData.GetAllAsync(n => n.RequiredPoint, true);

            if(levels is null)
            {
                throw new NullReferenceException();
            }

            return levels;
        }

        public Task<List<Level>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        

        public Task Update(Level entity)
        {
            throw new NotImplementedException();
        }
    }
}
