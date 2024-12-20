using Debat.Core.Application.Repositories;
using Debat.Core.Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Debat.Persistence.Repositories;

public class RepositoryBase<TEntity, TContext>(TContext context) : IRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? condition = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        TEntity entity = await GenerateGetQuery(condition, includes).FirstOrDefaultAsync();

        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? condition = null,
                                                 Expression < Func<TEntity, object>>? orderBy = null,
                                                 bool isAscending = true,
                                                 params Expression<Func<TEntity, object>>[] includes)
    {
        List<TEntity> entities = await GenerateGetAllQuery(condition, orderBy, isAscending, includes)
                                       .ToListAsync();

        return entities;
    }
    public async Task<List<TEntity>> GetAllPaginatedAsync(int currentPage,
                                                          int pageCapacity,
                                                          Expression<Func<TEntity, bool>>? condition = null,
                                                          Expression<Func<TEntity, object>>? orderBy = null,
                                                          bool isAscending = true,
                                                          params Expression<Func<TEntity, object>>[] includes)
    {
        List<TEntity> entities = await GenerateGetAllPaginatedQuery(currentPage, pageCapacity, condition, orderBy, isAscending, includes)
                                                       .ToListAsync();
        return entities;
    }

    public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>>? condition = null)
    {
        IQueryable<TEntity> query = GenerateDefaultQuery();

        if(condition is not null) query = AddConditionToQuery(query, condition);

        int count = await query.CountAsync();

        return count;
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

    private IQueryable<TEntity> GenerateDefaultQuery()
    {
        return context.Set<TEntity>().AsNoTracking().AsQueryable();
    }

    private IQueryable<TEntity> GenerateGetQuery(Expression<Func<TEntity, bool>>? condition = null,
                                                 params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GenerateDefaultQuery();

        if (condition is not null) query = AddConditionToQuery(query, condition);

        if (includes is not null) query = AddIncludesToQuery(query, includes);

        return query;
    }

    private IQueryable<TEntity> GenerateGetAllQuery(Expression<Func<TEntity, bool>>? condition = null,
                                                    Expression<Func<TEntity, object>>? orderBy = null,
                                                    bool isAscending = true,
                                                    params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GenerateDefaultQuery();

        if (condition is not null) query = AddConditionToQuery(query, condition);

        if (includes is not null) query = AddIncludesToQuery(query, includes);

        if (orderBy is not null) query = AddOrderByToQuery(query, orderBy, isAscending);

        return query;
    }

    private IQueryable<TEntity> GenerateGetAllPaginatedQuery(int currentPageNumber,
                                                             int pageCapacity,
                                                             Expression<Func<TEntity, bool>>? condition = null,
                                                             Expression<Func<TEntity, object>>? orderBy = null,
                                                             bool isAscending = true,
                                                             params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GenerateGetAllQuery(condition, orderBy, isAscending, includes)
                                                  .Skip((currentPageNumber - 1) * pageCapacity)
                                                  .Take(pageCapacity);

        return query;
    }


    private IQueryable<TEntity> AddConditionToQuery(IQueryable<TEntity> query,
                                                    Expression<Func<TEntity, bool>> condition)
    {
        query = query.Where(condition);

        return query;
    }

    private IQueryable<TEntity> AddSelectorToQuery(IQueryable<TEntity> query,
                                                   Expression<Func<TEntity, TEntity>> selector)
    {
        query = query.Select(selector);

        return query;
    }

    private IQueryable<TEntity> AddIncludesToQuery(IQueryable<TEntity> query,
                                                   params Expression<Func<TEntity, object>>[] includes)
    {
        foreach (Expression<Func<TEntity, object>> include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

    private IQueryable<TEntity> AddOrderByToQuery(IQueryable<TEntity> query,
                                                  Expression<Func<TEntity, object>> orderBy,
                                                  bool isAscending)
    {
        if (isAscending)
        {
            return query.OrderBy(orderBy);
        }
        else
        {
            return query.OrderByDescending(orderBy);
        }
    }
}