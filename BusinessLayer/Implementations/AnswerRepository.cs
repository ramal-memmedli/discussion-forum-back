using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class AnswerRepository : IAnswerService
    {
        private readonly IAnswerData _answerData;

        public AnswerRepository(IAnswerData answerData)
        {
            _answerData = answerData;
        }

        public async Task<Answer> Get(int id)
        {
            Answer answer = await _answerData.GetAsync(n => n.Id == id && !n.IsDeleted, "AppUser", "AnswerVotes");

            if(answer is null)
            {
                throw new NullReferenceException();
            }

            return answer;
        }

        public async Task<List<Answer>> GetAllByTopicId(int id)
        {
            List<Answer> answers = await _answerData.GetAllAsync(n => n.CreateDate, false, n => !n.IsDeleted && n.TopicId == id, "AppUser", "AnswerVotes");

            if(answers is null)
            {
                throw new NullReferenceException();
            }

            return answers;
        }

        public async Task Create(Answer entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreateDate = DateTime.Now;
            entity.IsDeleted = false;

            await _answerData.AddAsync(entity);
        }

        public async Task<int> GetTotalCountByTopicId(int id)
        {
            return await _answerData.GetTotalCountAsync(n => n.TopicId == id && !n.IsDeleted);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<List<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Answer>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        

        public Task Update(Answer entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
