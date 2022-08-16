using BusinessLayer.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IAnswerService : IBaseService<Answer>
    {
        Task<int> GetTotalCountByTopicId(int id);
        Task<List<Answer>> GetAllByTopicId(int id);
    }
}
