using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface IAnswerService : IBaseService<Answer>
{
    Task<int> GetTotalCountByTopicId(int id);
    Task<List<Answer>> GetAllByTopicId(int id);
}