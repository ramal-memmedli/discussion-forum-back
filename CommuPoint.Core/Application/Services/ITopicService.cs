using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Application.Services
{
    public interface ITopicService : IBaseService<Topic>
    {
        Task<List<Topic>> GetAllByAuthor(string id);
        Task<List<Topic>> GetAllBySearch(string content);
    }
}
