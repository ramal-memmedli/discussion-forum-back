using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BookmarkRepository : IBookmarkService
    {
        private readonly IBookmarkData _bookmarkData;

        public BookmarkRepository(IBookmarkData bookmarkData)
        {
            _bookmarkData = bookmarkData;
        }

        public async Task Create(UserBookmark entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            await _bookmarkData.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            UserBookmark bookmark = await Get(id);

            await _bookmarkData.DeleteAsync(bookmark);
        }

        public async Task<UserBookmark> Get(int id)
        {
            UserBookmark bookmark = await _bookmarkData.GetAsync(n => n.Id == id);

            if(bookmark is null)
            {
                throw new NullReferenceException();
            }

            return bookmark;
        }

        public async Task<List<UserBookmark>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserBookmark>> GetAllByUserId(string userId)
        {
            List<UserBookmark> bookmarks = await _bookmarkData.GetAllAsync(null, true, n => n.AppUserId == userId, "Topic");

            if(bookmarks is null)
            {
                throw new NullReferenceException();
            }

            return bookmarks;
        }

        public Task<List<UserBookmark>> GetAllPaginated(int currentPage, int pageCapacity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBookmark> GetByTopicId(int id)
        {
            UserBookmark bookmark = await _bookmarkData.GetAsync(n => n.TopicId == id);

            if (bookmark is null)
            {
                throw new NullReferenceException();
            }

            return bookmark;
        }

        public Task<int> GetTotalCount()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserBookmark entity)
        {
            throw new NotImplementedException();
        }
    }
}
