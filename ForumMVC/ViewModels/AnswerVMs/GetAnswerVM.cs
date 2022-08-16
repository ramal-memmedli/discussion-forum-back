using DataAccessLayer.Models;
using System.Collections.Generic;
using System;
using ForumMVC.ViewModels.CommentVMs;

namespace ForumMVC.ViewModels.AnswerVMs
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
        public bool IsVotedByYou { get; set; }
        public string YourVote { get; set; }
        public int VoteCount { get; set; }
        public int CommentCount { get; set; }
        public List<GetCommentVM> Comments { get; set; }
    }
}
