using BusinessLayer.Base;
using CoreLayer.Entity;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICommunityService : IBaseService<Community>
    {
        Task<List<Community>> GetAllAscOrdered(Expression<Func<Community, object>> orderBy = null);

        Task<List<Community>> GetAllDescOrdered(Expression<Func<Community, object>> orderBy = null);
    }
}
