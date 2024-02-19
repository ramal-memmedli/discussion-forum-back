using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Application.Services;
using CommuPoint.Core.Domain.Entities;

namespace CommuPoint.Business.Services
{
    public class AnswerVoteRepository : IAnswerVoteService
    {
        private readonly IAnswerVoteData _answerVoteData;

        public AnswerVoteRepository(IAnswerVoteData answerVoteData)
        {
            _answerVoteData = answerVoteData;
        }

        public async Task Create(AnswerVote entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            await _answerVoteData.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            AnswerVote answerVote = await Get(id);

            await _answerVoteData.DeleteAsync(answerVote);
        }

        public async Task<AnswerVote> Get(int id)
        {
            AnswerVote answerVote = await _answerVoteData.GetAsync(n => n.Id == id, "AppUser", "Answer");

            if(answerVote is null)
            {
                throw new NullReferenceException();
            }

            return answerVote;
        }

        public Task<List<AnswerVote>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<AnswerVote>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public async Task Update(AnswerVote entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            await _answerVoteData.UpdateAsync(entity);
        }
    }
}
