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
        public List<CommunityTopic> CommunityTopics { get; set; }
        public List<TopicAnswer> TopicAnswers { get; set; }
        public List<TopicCategory> TopicCategories { get; set; }
        public DbSet<UserBookmark> UserBookmarks { get; set; }
    }
}
