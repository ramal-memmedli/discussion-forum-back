using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.ViewModels
{
    public class GetAnswerVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string AuthorUsername { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorLevel { get; set; }
        public string AuthorFullname { get; set; }
        public bool AreYouAuthor { get; set; }
        public bool IsVotedByYou { get; set; }
        public string YourVote { get; set; }
        public int VoteCount { get; set; }
        public int CommentCount { get; set; }
        public List<GetCommentVM> Comments { get; set; }
    }
}
