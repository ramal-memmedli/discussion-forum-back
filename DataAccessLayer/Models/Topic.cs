using CoreLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Topic : IEntity
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserBookmark> UserBookmarks { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
