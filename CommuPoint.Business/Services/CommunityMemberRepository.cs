using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Application.Services;
using CommuPoint.Core.Domain.Entities;

namespace CommuPoint.Business.Services
{
    public class CommunityMemberRepository : ICommunityMemberService
    {
        private readonly ICommunityMemberData _communityMemberData;

        public CommunityMemberRepository(ICommunityMemberData communityMemberData)
        {
            _communityMemberData = communityMemberData;
        }

        public async Task<CommunityMember> Get(int id)
        {
            CommunityMember communityMember = await _communityMemberData.GetAsync(n => n.Id == id, "AppUser");

            if(communityMember is null)
            {
                throw new NullReferenceException();
            }

            return communityMember;
        }

        public async Task<List<CommunityMember>> GetAll()
        {
            List<CommunityMember> communityMembers = await _communityMemberData.GetAllAsync();

            if(communityMembers is null)
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
