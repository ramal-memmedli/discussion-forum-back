using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Implementations;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class ImageRepository : IImageService
    {
        private readonly IImageData _imageData;

        public ImageRepository(IImageData imageData)
        {
            _imageData = imageData;
        }

        public async Task<Image> Get(int id)
        {
            Image image = await _imageData.GetAsync(n => n.Id == id);

            if(image is null)
            {
                throw new NullReferenceException();
            }

            return image;
        }

        public async Task<List<Image>> GetAll()
        {
            List<Image> images = await _imageData.GetAllAsync();

            if(images is null)
            {
                throw new NullReferenceException();
            }

            return images;
        }

        public Task<List<Image>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public async Task Create(Image entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _imageData.AddAsync(entity);
        }

        public Task Update(Image entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
