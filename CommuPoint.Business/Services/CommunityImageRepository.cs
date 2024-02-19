using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Application.Services;
using CommuPoint.Core.Domain.Entities;

namespace CommuPoint.Business.Services
{
    public class CommunityImageRepository : ICommunityImageService
    {
        private readonly ICommunityImageData _communityImageData;

        public CommunityImageRepository(ICommunityImageData communityImageData)
        {
            _communityImageData = communityImageData;
        }

        public Task<CommunityImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommunityImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<CommunityImage>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Create(CommunityImage entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(CommunityImage entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
