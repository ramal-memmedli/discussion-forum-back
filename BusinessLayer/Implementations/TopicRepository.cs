using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class TopicRepository : ITopicService
    {
        private readonly ITopicData _topicData;

        public TopicRepository(ITopicData topicData)
        {
            _topicData = topicData;
        }

        public async Task<Topic> Get(int id)
        {
            Topic topic = await _topicData.GetAsync(n => n.Id == id && !n.IsDeleted, "Author", "Category");

            if(topic is null)
            {
                throw new NullReferenceException();
            }

            return topic;
        }

        public async Task<List<Topic>> GetAll()
        {
            List<Topic> topics = await _topicData.GetAllAsync();

            if(topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<List<Topic>> GetAllByAuthor(string id)
        {
            List<Topic> topics = await _topicData.GetAllAsync(n => n.CreateDate, false, n => !n.IsDeleted && n.AuthorId == id, "Author", "Category");

            if (topics is null)
            {
                throw new NullReferenceException();
            }

            return topics;
        }

        public async Task<List<Topic>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            List<Topic> topics = await _topicData.GetAllPaginatedAsync(currentPage, pageCapacity, n => n.CreateDate, false, n => !n.IsDeleted, "Author", "Category");

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
            if(entity is null)
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
