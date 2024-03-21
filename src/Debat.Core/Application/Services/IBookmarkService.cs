using Debat.Core.Domain.Entities;
using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Application.Services;

public interface IBookmarkService : IBaseService<UserBookmark>
{
    Task<List<UserBookmark>> GetAllByUserId(string userId);
    Task<UserBookmark> GetByTopicId(int id);
}