using ForumMVC.ViewModels.TopicVMs;
using System.Collections.Generic;

namespace ForumMVC.ViewModels.UserVMs
{
    public class UserProfileVM
    {
        public GetUserVM User { get; set; }
        public List<GetTopicVM> Topics { get; set; }
    }
}
