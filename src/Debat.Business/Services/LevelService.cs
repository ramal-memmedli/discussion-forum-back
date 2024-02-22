using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Debat.Business.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelData;
        private readonly UserManager<AppUser> _userManager;

        public LevelService(ILevelRepository levelData, UserManager<AppUser> userManager)
        {
            _levelData = levelData;
            _userManager = userManager;
        }
        public async Task<Level> Get(int id)
        {
            Level level = await _levelData.GetAsync(n => n.Id == id);

            if (level is null)
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

            if (levels is null)
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

        public async Task UpgradeUserLevel(AppUser user)
        {
            List<Level> levels = await GetAll();

            foreach (Level level in levels)
            {
                if (user.Point >= level.RequiredPoint)
                {
                    user.LevelId = level.Id;

                    await _userManager.UpdateAsync(user);
                }
            }
        }
    }
}
