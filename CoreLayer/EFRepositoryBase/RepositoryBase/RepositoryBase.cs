using CoreLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.EFRepositoryBase.RepositoryBase
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(expression, includes);

            TEntity entity = await query.FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(expression, includes);

            List<TEntity> entities = await query.ToListAsync();

            return entities;
        }

        public async Task<List<TEntity>> GetAllPaginatedAsync(int currentPage, int pageCapacity, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetPaginatedQuery(currentPage, pageCapacity, expression, includes);

            List<TEntity> entities = await query.ToListAsync();

            return entities;
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            int entityCount = expression is null
                ? await _context.Set<TEntity>().CountAsync()
                : await _context.Set<TEntity>().Where(expression).CountAsync();

            return entityCount;
        }

        public async Task AddAsync(TEntity entity)
        {
            var data = _context.Entry(entity);
            data.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var data = _context.Entry(entity);
            data.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var data = _context.Entry(entity);
            data.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        private IQueryable<TEntity> GetPaginatedQuery(int currentPageNumber, int pageCapacity, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(expression, includes);

            query = query.Skip((currentPageNumber - 1) * pageCapacity).Take(pageCapacity);

            return query;
        }
    }
}
