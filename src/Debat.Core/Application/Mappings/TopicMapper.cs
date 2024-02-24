using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Mappings
{
    public static class TopicMapper
    {
        public static GetTopicVM MapToVM(this Topic topic, bool isInBookmarks, bool areYouAuthor, string authorImage, string authorLevel, List<GetAnswerVM> answerVM)
        {
            GetTopicVM vm = new GetTopicVM();

            vm.Id = topic.Id;
            vm.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
            vm.AuthorUsername = topic.Author.UserName;
            vm.AuthorLevel = authorLevel;
            vm.AuthorImage = authorImage;
            vm.Title = topic.Title;
            vm.Content = topic.Content;
            vm.ViewCount = topic.ViewCount;
            vm.AnswerCount = answerVM.Count;
            vm.AreYouAuthor = areYouAuthor;
            vm.IsInBookmarks = isInBookmarks;
            vm.CreateDate = topic.CreateDate;
            vm.UpdateDate = topic.UpdateDate;
            vm.TopicCategory = new GetTopicCategoryVM
            {
                Id = topic.CategoryId,
                Name = topic.Category.Name
            };
            vm.Answers = answerVM;

            return vm;
        }

        public static Topic MapToModel(this CreateTopicVM topicVM,
                                       string userId)
        {
            Topic topic = new Topic();

            topic.Title = topicVM.Title;
            topic.Content = topicVM.Content;
            topic.CategoryId = topicVM.CategoryId;
            topic.AuthorId = userId;

            return topic;
        }
    }
}
