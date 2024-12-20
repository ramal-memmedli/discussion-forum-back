using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface IUserImageService : IBaseService<UserImage>
{
    Task<List<UserImage>> GetAllByUserId(string? id);
    Task<Image?> GetUsersProfileImage(string? id);
    Task<Image?> GetUsersProfileBanner(string? id);
}