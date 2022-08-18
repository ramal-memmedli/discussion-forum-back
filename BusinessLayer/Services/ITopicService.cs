using BusinessLayer.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ITopicService : IBaseService<Topic>
    {
        Task<List<Topic>> GetAllByAuthor(string id);
        Task<List<Topic>> GetAllBySearch(string content);
    }
}
