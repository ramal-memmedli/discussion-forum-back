using BusinessLayer.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IBookmarkService : IBaseService<UserBookmark>
    {
        Task<List<UserBookmark>> GetAllByUserId(string userId);
        Task<UserBookmark> GetByTopicId(int id);
    }
}
