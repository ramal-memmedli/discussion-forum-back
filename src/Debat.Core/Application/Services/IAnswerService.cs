using Debat.Core.Domain.Entities;
using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Application.Services;

public interface IAnswerService : IBaseService<Answer>
{
    Task<int> GetTotalCountByTopicId(int id);
    Task<List<Answer>> GetAllByTopicId(int id);
}