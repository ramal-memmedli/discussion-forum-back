using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Image> Images { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityTopic> CommunityTopics { get; set; }
        public DbSet<CommunityMember> CommunityMembers { get; set; }
        public DbSet<CommunityImage> CommunityImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicCategory> TopicCategories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerVote> AnswerVotes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }
        public DbSet<TopicAnswer> TopicAnswers { get; set; }
        public DbSet<UserBookmark> UserBookmarks { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
    }
}
