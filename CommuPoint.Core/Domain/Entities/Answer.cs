using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<AnswerVote> AnswerVotes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
