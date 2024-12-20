﻿using System.Linq.Expressions;
using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Application.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? condition = null,
                           params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? condition = null,
                                    Expression < Func<TEntity, object>>? orderBy = null,
                                    bool isAscending = true,
                                    params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> GetAllPaginatedAsync(int currentPage,
                                             int pageCapacity,
                                             Expression<Func<TEntity, bool>>? condition = null,
                                             Expression<Func<TEntity, object>>? orderBy = null,
                                             bool isAscending = true,
                                             params Expression<Func<TEntity, object>>[] includes);
    Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>>? condition = null);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}