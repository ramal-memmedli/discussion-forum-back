using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class UserImageService : IUserImageService
    {
        private readonly IUserImageRepository _userImageData;

        public UserImageService(IUserImageRepository userImageData)
        {
            _userImageData = userImageData;
        }

        public async Task<UserImage> Get(int id)
        {
            UserImage image = await _userImageData.GetAsync(n => n.Id == id, "Image");

            if (image is null)
            {
                throw new NullReferenceException();
            }

            return image;
        }

        public async Task<List<UserImage>> GetAllByUserId(string? id)
        {
            List<UserImage> images = await _userImageData.GetAllAsync(null, true, n => n.AppUserId == id, "Image");

            if (images is null)
            {
                throw new NullReferenceException();
            }

            return images;
        }

        public async Task Create(UserImage entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _userImageData.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }



        public Task<List<UserImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserImage>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserImage entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _userImageData.UpdateAsync(entity);
        }

        public async Task<Image?> GetUsersProfileImage(string? id)
        {
            List<UserImage> userImages = await GetAllByUserId(id);

            foreach (UserImage userImage in userImages)
            {
                if (userImage.Target == "profile")
                {
                    if (userImages is null)
                    {
                        throw new NullReferenceException();
                    }

                    return userImage.Image;
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Image?> GetUsersProfileBanner(string? id)
        {
            List<UserImage> userImages = await GetAllByUserId(id);

            foreach (UserImage userImage in userImages)
            {
                if (userImage.Target == "banner")
                {
                    if (userImages is null)
                    {
                        throw new NullReferenceException();
                    }

                    return userImage.Image;
                }
            }

            throw new NullReferenceException();
        }
    }
}
