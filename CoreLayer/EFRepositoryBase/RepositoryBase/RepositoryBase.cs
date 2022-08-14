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

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy = null, bool isAscending = true, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetAllQuery(isAscending, orderBy, expression, includes);

            List<TEntity> entities = await query.ToListAsync();

            return entities;
        }

        public async Task<List<TEntity>> GetAllPaginatedAsync(int currentPage, int pageCapacity, Expression<Func<TEntity, object>> orderBy = null, bool isAscending = true, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetAllPaginatedQuery(currentPage, pageCapacity, isAscending, orderBy, expression, includes);

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
                query = AddExpressionToQuery(query, expression);
            }

            if (includes != null)
            {
                query = AddIncludesToQuery(query, includes);
            }

            return query;
        }

        private IQueryable<TEntity> GetAllQuery(bool isAscending, Expression<Func<TEntity, object>> orderBy = null, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            if (expression != null)
            {
                query = AddExpressionToQuery(query, expression);
            }

            if (includes != null)
            {
                query = AddIncludesToQuery(query, includes);
            }

            if(orderBy != null)
            {
                query = AddOrderByToQuery(query, isAscending, orderBy);
            }

            return query;
        }

        private IQueryable<TEntity> GetAllPaginatedQuery(int currentPageNumber, int pageCapacity, bool isAscending, Expression<Func<TEntity, object>> orderBy = null, Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetAllQuery(isAscending, orderBy, expression, includes);

            query = query.Skip((currentPageNumber - 1) * pageCapacity).Take(pageCapacity);

            return query;
        }


        private IQueryable<TEntity> AddExpressionToQuery(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expression)
        {
            return query.Where(expression);
        }

        private IQueryable<TEntity> AddIncludesToQuery(IQueryable<TEntity> query, params string[] includes)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        private IQueryable<TEntity> AddOrderByToQuery(IQueryable<TEntity> query, bool isAscending, Expression<Func<TEntity, object>> orderBy = null)
        {
            if(isAscending)
            {
                query = query.OrderBy(orderBy);
            }else
            {
                query = query.OrderByDescending(orderBy);
            }
            return query;
        }
    }
}
