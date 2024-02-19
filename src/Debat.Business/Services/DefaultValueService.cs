using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class DefaultValueService : IDefaultValueService
    {
        private readonly IDefaultValueRepository _defaultValueData;

        public DefaultValueService(IDefaultValueRepository defaultValueData)
        {
            _defaultValueData = defaultValueData;
        }

        public Task<DefaultValue> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DefaultValue>> GetAll()
        {
            List<DefaultValue> values = await _defaultValueData.GetAllAsync();

            if (values is null)
            {
                throw new NullReferenceException();
            }

            return values;
        }

        public Task<List<DefaultValue>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Create(DefaultValue entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(DefaultValue entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
