using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Application.Services
{
    public interface IAnswerService : IBaseService<Answer>
    {
        Task<int> GetTotalCountByTopicId(int id);
        Task<List<Answer>> GetAllByTopicId(int id);
    }
}
