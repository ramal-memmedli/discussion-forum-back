using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class CommunityMemberService : ICommunityMemberService
    {
        private readonly ICommunityMemberRepository _communityMemberData;

        public CommunityMemberService(ICommunityMemberRepository communityMemberData)
        {
            _communityMemberData = communityMemberData;
        }

        public async Task<CommunityMember> Get(int id)
        {
            CommunityMember communityMember = await _communityMemberData.GetAsync(n => n.Id == id, "AppUser");

            if (communityMember is null)
            {
                throw new NullReferenceException();
            }

            return communityMember;
        }

        public async Task<List<CommunityMember>> GetAll()
        {
            List<CommunityMember> communityMembers = await _communityMemberData.GetAllAsync();

            if (communityMembers is null)
            {
                throw new NullReferenceException();
            }

            return communityMembers;
        }

        public Task<List<CommunityMember>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Create(CommunityMember entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(CommunityMember entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
