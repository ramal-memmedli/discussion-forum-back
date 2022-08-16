using BusinessLayer.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICommentService : IBaseService<Comment>
    {
        Task<List<Comment>> GetAllByAnswerId(int id);
    }
}
