using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class UserImageRepository : IUserImageService
    {
        private readonly IUserImageData _userImageData;

        public UserImageRepository(IUserImageData userImageData)
        {
            _userImageData = userImageData;
        }

        public async Task<UserImage> Get(int id)
        {
            UserImage image = await _userImageData.GetAsync(n => n.Id == id, "Image");

            if(image is null)
            {
                throw new NullReferenceException();
            }

            return image;
        }

        public async Task<List<UserImage>> GetAllByUserId(string id)
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
            if(entity is null)
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

        public Task Update(UserImage entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
