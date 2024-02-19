using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Application.Services
{
    public interface IBookmarkService : IBaseService<UserBookmark>
    {
        Task<List<UserBookmark>> GetAllByUserId(string userId);
        Task<UserBookmark> GetByTopicId(int id);
    }
}
