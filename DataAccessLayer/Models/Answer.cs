using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<AnswerVote> AnswerVotes { get; set; }
        public List<AnswerComment> AnswerComments { get; set; }
        public List<TopicAnswer> TopicAnswers { get; set; }
    }
}
