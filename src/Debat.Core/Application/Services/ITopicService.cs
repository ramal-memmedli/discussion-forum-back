using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface ITopicService : IBaseService<Topic>
{
    Task<List<Topic>> GetAllByAuthor(string id);
    Task<List<Topic>> GetAllBySearch(string content);
}