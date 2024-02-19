using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.Repositories;

namespace CommuPoint.Persistence.DataConcretes
{
    public class DefaultValueData : RepositoryBase<DefaultValue, CommuPointDbContext>, IDefaultValueData
    {
        public DefaultValueData(CommuPointDbContext contex) : base(contex)
        {

        }
    }
}
