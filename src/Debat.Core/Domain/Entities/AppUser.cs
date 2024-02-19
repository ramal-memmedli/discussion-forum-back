using Microsoft.AspNetCore.Identity;

namespace Debat.Core.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<UserImage> UserImages { get; set; }
        public List<CommunityMember> CommunityMembers { get; set; }
        public List<AnswerVote> AnswerVotes { get; set; }
        public List<UserBookmark> UserBookmarks { get; set; }
        public string About { get; set; }
        public int Point { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}
