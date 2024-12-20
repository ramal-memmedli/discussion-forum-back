﻿using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;

namespace Debat.Business.Services
{
    public class AnswerVoteService : IAnswerVoteService
    {
        private readonly IAnswerVoteRepository _answerVoteData;

        public AnswerVoteService(IAnswerVoteRepository answerVoteData)
        {
            _answerVoteData = answerVoteData;
        }

        public async Task Create(AnswerVote entity)
        {
            if (entity is null)
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
            AnswerVote answerVote = await _answerVoteData.GetAsync(n => n.Id == id, n => n.AppUser, n => n.Answer);

            if (answerVote is null)
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
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _answerVoteData.UpdateAsync(entity);
        }
    }
}
