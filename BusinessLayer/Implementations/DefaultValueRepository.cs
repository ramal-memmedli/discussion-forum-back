using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class DefaultValueRepository : IDefaultValueService
    {
        private readonly IDefaultValueData _defaultValueData;

        public DefaultValueRepository(IDefaultValueData defaultValueData)
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

            if(values is null)
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
