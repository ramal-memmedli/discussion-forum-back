using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.ViewModels
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

        public void Map(Topic topic, bool isInBookmarks, bool areYouAuthor, string authorImage, string authorLevel, List<GetAnswerVM> answerVM)
        {
            Id = topic.Id;
            AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
            AuthorUsername = topic.Author.UserName;
            AuthorLevel = authorLevel;
            AuthorImage = authorImage;
            Title = topic.Title;
            Content = topic.Content;
            ViewCount = topic.ViewCount;
            AnswerCount = answerVM.Count;
            AreYouAuthor = areYouAuthor;
            IsInBookmarks = isInBookmarks;
            CreateDate = topic.CreateDate;
            UpdateDate = topic.UpdateDate;
            TopicCategory = new GetTopicCategoryVM
            {
                Id = topic.CategoryId,
                Name = topic.Category.Name
            };
            Answers = answerVM;
        }
    }
}
