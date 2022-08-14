using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class CommunityRepository : ICommunityService
    {
        private readonly ICommunityData _communityData;

        public CommunityRepository(ICommunityData communityData)
        {
            _communityData = communityData;
        }

        public async Task<Community> Get(int id)
        {
            Community community = await _communityData.GetAsync(n => !n.IsDeleted && n.Id == id, "CommunityMembers", "CommunityTopics", "CommunityImages");

            if(community is null)
            {
                throw new NullReferenceException();
            }

            return community;
        }

        public async Task<List<Community>> GetAll()
        {
            List<Community> communities = await _communityData.GetAllAsync(null, true, n => !n.IsDeleted, "CommunityMembers", "CommunityTopics", "CommunityImages");

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllAscOrdered(Expression<Func<Community, object>> orderBy = null)
        {
            List<Community> communities = await _communityData.GetAllAsync(orderBy, true, n => !n.IsDeleted, "CommunityMembers", "CommunityTopics", "CommunityImages");

            if (communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllDescOrdered(Expression<Func<Community, object>> orderBy = null)
        {
            List<Community> communities = await _communityData.GetAllAsync(orderBy, false, n => !n.IsDeleted, "CommunityMembers", "CommunityTopics", "CommunityImages");

            if(communities is null)
            {
                throw new NullReferenceException();
            }

            return communities;
        }

        public async Task<List<Community>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            List<Community> communities = await _communityData.GetAllPaginatedAsync(currentPage, pageCapacity, null, true, n => !n.IsDeleted, "CommunityMembers", "CommunityTopics", "CommunityImages");

            if(communities is null)
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
            if(entity is null)
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
