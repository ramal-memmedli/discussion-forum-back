using System;

namespace ForumMVC.ViewModels.TopicVMs
{
    public class GetTopicVM
    {
        public int Id { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorUsername { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
