using ForumMVC.ViewModels.AnswerVMs;
using System;
using System.Collections.Generic;

namespace ForumMVC.ViewModels.TopicVMs
{
    public class GetTopicVM
    {
        public int Id { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorUsername { get; set; }
        public string AuthorLevel { get; set; }
        public string AuthorImage { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public int AnswerCount { get; set; }
        public bool AreYouAuthor { get; set; }
        public bool IsInBookmarks { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public GetTopicCategoryVM TopicCategory { get; set; }
        public List<GetAnswerVM> Answers { get; set; }
    }
}
