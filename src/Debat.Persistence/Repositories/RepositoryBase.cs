using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Debat.Persistence.Repositories;

public class RepositoryBase<TEntity, TContext>(TContext context) : IRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        return await GenerateGetQuery(expression, includes).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> orderBy = null,
        bool isAscending = true,
        Expression<Func<TEntity, bool>> expression = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAllQuery(isAscending,
            orderBy,
            expression,
            includes).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllPaginatedAsync(int currentPage,
        int pageCapacity,
        Expression<Func<TEntity, object>> orderBy = null,
        bool isAscending = true,
        Expression<Func<TEntity, bool>> expression = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAllPaginatedQuery(currentPage,
            pageCapacity,
            isAscending,
            orderBy,
            expression,
            includes).ToListAsync();
    }

    public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        return expression is null
            ? await context.Set<TEntity>().CountAsync()
            : await context.Set<TEntity>().Where(expression).CountAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        var data = context.Entry(entity);
        data.State = EntityState.Added;
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var data = context.Entry(entity);
        data.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        var data = context.Entry(entity);
        data.State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }

    private IQueryable<TEntity> GenerateGetQuery(Expression<Func<TEntity, bool>> expression = null,
                                                 params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking().AsQueryable();

        if (expression != null) query = AddExpressionToQuery(query, expression);

        if (includes != null) query = AddIncludesToQuery(query, includes);

        return query;
    }

    private IQueryable<TEntity> GetAllQuery(bool isAscending,
        Expression<Func<TEntity, object>> orderBy = null,
        Expression<Func<TEntity, bool>> expression = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking().AsQueryable();

        if (expression != null) query = AddExpressionToQuery(query, expression);

        if (includes != null) query = AddIncludesToQuery(query, includes);

        if (orderBy != null) return AddOrderByToQuery(query, isAscending, orderBy);

        return query;
    }

    private IQueryable<TEntity> GetAllPaginatedQuery(int currentPageNumber,
        int pageCapacity,
        bool isAscending,
        Expression<Func<TEntity, object>> orderBy = null,
        Expression<Func<TEntity, bool>> expression = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        return GetAllQuery(isAscending,
                orderBy,
                expression,
                includes)
            .Skip((currentPageNumber - 1) * pageCapacity)
            .Take(pageCapacity);
    }


    private IQueryable<TEntity> AddExpressionToQuery(IQueryable<TEntity> query,
                                                     Expression<Func<TEntity, bool>> expression)
    {
        return query.Where(expression);
    }

    private IQueryable<TEntity> AddSelectorToQuery(IQueryable<TEntity> query,
                                                   Expression<Func<TEntity, TEntity>> selector)
    {
        return query.Select(selector);
    }

    private IQueryable<TEntity> AddIncludesToQuery(IQueryable<TEntity> query,
                                                   params Expression<Func<TEntity, object>>[] includes)
    {
        foreach (Expression<Func<TEntity, object>> include in includes) query = query.Include(include);
        return query;
    }

    private IQueryable<TEntity> AddOrderByToQuery(IQueryable<TEntity> query,
        bool isAscending,
        Expression<Func<TEntity, object>> orderBy = null)
    {
        return isAscending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
    }
}