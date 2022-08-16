using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using System.Collections.Generic;

namespace ForumMVC.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public GetUserCardVM UserCard { get; set; }
        public List<GetTopicVM> Topics { get; set; }
    }
}
