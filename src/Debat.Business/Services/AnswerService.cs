using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerData;

        public AnswerService(IAnswerRepository answerData)
        {
            _answerData = answerData;
        }

        public async Task<Answer> Get(int id)
        {
            Answer answer = await _answerData.GetAsync(n => n.Id == id && !n.IsDeleted, n => n.AppUser, n => n.AnswerVotes);

            if (answer is null)
            {
                throw new NullReferenceException();
            }

            return answer;
        }

        public async Task<List<Answer>> GetAllByTopicId(int id)
        {
            List<Answer> answers = await _answerData.GetAllAsync(n => !n.IsDeleted && n.TopicId == id, n => n.CreateDate, false, n => n.AppUser, n => n.AnswerVotes);

            if (answers is null)
            {
                throw new NullReferenceException();
            }

            return answers;
        }

        public async Task<int> GetTotalCountByTopicId(int id)
        {
            return await _answerData.GetTotalCountAsync(n => n.TopicId == id && !n.IsDeleted);
        }

        public async Task Create(Answer entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreateDate = DateTime.Now;
            entity.IsDeleted = false;

            await _answerData.AddAsync(entity);
        }

        public async Task Update(Answer entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdateDate = DateTime.Now;

            await _answerData.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            Answer answer = await Get(id);

            answer.IsDeleted = true;

            await Update(answer);
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
    }
}
