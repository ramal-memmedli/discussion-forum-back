using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageData;

        public ImageService(IImageRepository imageData)
        {
            _imageData = imageData;
        }

        public async Task<Image> Get(int id)
        {
            Image image = await _imageData.GetAsync(n => n.Id == id);

            if (image is null)
            {
                throw new NullReferenceException();
            }

            return image;
        }

        public async Task<List<Image>> GetAll()
        {
            List<Image> images = await _imageData.GetAllAsync();

            if (images is null)
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
