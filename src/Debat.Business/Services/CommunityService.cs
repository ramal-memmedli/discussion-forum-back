using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Debat.Business.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly ICommunityRepository _communityData;

        public CommunityService(ICommunityRepository communityData)
        {
            _communityData = communityData;
        }

        public async Task<Community> Get(int id)
        {
            Community community = await _communityData.GetAsync(n => !n.IsDeleted && n.Id == id, n => n.CommunityMembers, n => n.CommunityImages);

            if (community is null)
            {
                throw new NullReferenceException();
            }

            return community;
        }

        public async Task<List<Community>> GetAll()
        {
            List<Community> communities = await _communityData.GetAllAsync(n => !n.IsDeleted, null, true, n => n.CommunityMembers, n => n.CommunityImages);

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllAscOrdered(Expression<Func<Community, object>> orderBy = null)
        {
            List<Community> communities = await _communityData.GetAllAsync(n => !n.IsDeleted, orderBy, true, n => n.CommunityMembers, n => n.CommunityImages);

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllDescOrdered(Expression<Func<Community, object>> orderBy = null)
        {
            List<Community> communities = await _communityData.GetAllAsync(n => !n.IsDeleted, orderBy, false, n => n.CommunityMembers, n => n.CommunityImages);

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            List<Community> communities = await _communityData.GetAllPaginatedAsync(currentPage, pageCapacity, n => !n.IsDeleted, null, true, n => n.CommunityMembers, n => n.CommunityImages);

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<int> GetTotalCount()
        {
            int communityCount = await _communityData.GetTotalCountAsync(n => !n.IsDeleted);
            return communityCount;
        }

        public async Task Create(Community entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreateDate = DateTime.Now;
            entity.IsDeleted = false;

            await _communityData.AddAsync(entity);
        }

        public async Task Update(Community entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdateDate = DateTime.Now;

            await _communityData.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            Community community = await Get(id);

            community.IsDeleted = true;

            await Update(community);
        }
    }
}
