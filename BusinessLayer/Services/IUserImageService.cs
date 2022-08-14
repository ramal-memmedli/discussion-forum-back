using BusinessLayer.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserImageService : IBaseService<UserImage>
    {
        Task<List<UserImage>> GetAllByUserId(string id);
    }
}
