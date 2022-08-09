﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Base
{
    public interface IBaseService<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllPaginated(int currentPage, int pageCapacity);
        Task<int> GetTotalCount();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
