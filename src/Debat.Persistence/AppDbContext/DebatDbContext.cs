using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Debat.Persistence.AppDbContext;

public class DebatDbContext : IdentityDbContext<AppUser>
{
    public DebatDbContext(DbContextOptions<DebatDbContext> context) : base(context) { }

    public DbSet<Image> Images { get; set; }
    public DbSet<UserImage> UserImages { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<CommunityMember> CommunityMembers { get; set; }
    public DbSet<CommunityImage> CommunityImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<AnswerVote> AnswerVotes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserBookmark> UserBookmarks { get; set; }
    public DbSet<UserFollower> UserFollowers { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<DefaultValue> DefaultValues { get; set; }
}