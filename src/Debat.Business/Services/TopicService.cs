using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicData;

        public TopicService(ITopicRepository topicData)
        {
            _topicData = topicData;
        }

        public async Task<Topic> Get(int id)
        {
            Topic topic = await _topicData.GetAsync(n => n.Id == id && !n.IsDeleted, n=> n.Author, n => n.Category);

            if (topic is null)
            {
                throw new NullReferenceException();
            }

            return topic;
        }

        public async Task<List<Topic>> GetAll()
        {
            List<Topic> topics = await _topicData.GetAllAsync();

            if (topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<List<Topic>> GetAllByAuthor(string id)
        {
            List<Topic> topics = await _topicData.GetAllAsync(n => n.CreateDate, false, n => !n.IsDeleted && n.AuthorId == id, n => n.Author, n => n.Category);

            if (topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<List<Topic>> GetAllBySearch(string content)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException();
            }

            List<Topic> topics = await _topicData.GetAllAsync(n => n.Title, true, n => n.Title.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")) || n.Content.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")) || n.Category.Name.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")) || n.Author.Name.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")) || n.Author.Surname.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")) || n.Author.UserName.Trim().Replace(" ", "").Contains(content.Trim().Replace(" ", "")), n => n.Author, n => n.Category);

            if (topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<List<Topic>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            List<Topic> topics = await _topicData.GetAllPaginatedAsync(currentPage, pageCapacity, n => n.CreateDate, false, n => !n.IsDeleted, n => n.Author, n => n.Category);

            if (topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<int> GetTotalCount()
        {
            int topicCount = await _topicData.GetTotalCountAsync(n => !n.IsDeleted);

            return topicCount;
        }

        public async Task Create(Topic entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreateDate = DateTime.Now;
            entity.IsDeleted = false;

            await _topicData.AddAsync(entity);
        }

        public async Task Update(Topic entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdateDate = DateTime.Now;

            await _topicData.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            Topic topic = await Get(id);

            topic.IsDeleted = true;

            await Update(topic);
        }
    }
}
