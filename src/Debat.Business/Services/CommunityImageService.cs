using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class CommunityImageService : ICommunityImageService
    {
        private readonly ICommunityImageRepository _communityImageData;

        public CommunityImageService(ICommunityImageRepository communityImageData)
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
