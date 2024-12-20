using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface IBookmarkService : IBaseService<UserBookmark>
{
    Task<List<UserBookmark>> GetAllByUserId(string userId);
    Task<UserBookmark> GetByTopicId(int id);
}