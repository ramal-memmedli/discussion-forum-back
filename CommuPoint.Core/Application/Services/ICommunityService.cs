using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;
using System.Linq.Expressions;

namespace CommuPoint.Core.Application.Services
{
    public interface ICommunityService : IBaseService<Community>
    {
        Task<List<Community>> GetAllAscOrdered(Expression<Func<Community, object>> orderBy = null);

        Task<List<Community>> GetAllDescOrdered(Expression<Func<Community, object>> orderBy = null);
    }
}
