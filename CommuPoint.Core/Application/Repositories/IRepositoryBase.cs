using CommuPoint.Core.Domain.Models.Abstract;
using System.Linq.Expressions;

namespace CommuPoint.Core.Application.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy = null, bool isAscending = true, Expression<Func<TEntity, bool>> expression = null, params string[] includes);
        Task<List<TEntity>> GetAllPaginatedAsync(int currentPage, int pageCapacity, Expression<Func<TEntity, object>> orderBy = null, bool isAscending = true, Expression<Func<TEntity, bool>> expression = null, params string[] includes);
        Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
