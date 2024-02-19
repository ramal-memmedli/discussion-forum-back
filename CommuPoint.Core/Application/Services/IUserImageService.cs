using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Application.Services
{
    public interface IUserImageService : IBaseService<UserImage>
    {
        Task<List<UserImage>> GetAllByUserId(string id);
    }
}
