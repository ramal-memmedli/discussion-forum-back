using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class CommentRepository : ICommentService
    {
        private readonly ICommentData _commentData;

        public CommentRepository(ICommentData commentData)
        {
            _commentData = commentData;
        }

        public async Task<List<Comment>> GetAllByAnswerId(int id)
        {
            List<Comment> comments = await _commentData.GetAllAsync(n => n.CreateDate, false, n => n.AnswerId == id, "AppUser");

            if(comments is null)
            {
                throw new NullReferenceException();
            }

            return comments;
        }

        public async Task Create(Comment entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreateDate = DateTime.Now;

            await _commentData.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        

        public Task<List<Comment>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
