using DataAccessLayer.Models;
using System.Collections.Generic;
using System;
using ForumMVC.ViewModels.UserVMs;
using ForumMVC.ViewModels.TopicVMs;

namespace ForumMVC.ViewModels.CommunityVMs
{
    public class GetCommunityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Point { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ProfileImage { get; set; }
        public string BannerImage { get; set; }
        public List<GetTopicVM> Topics { get; set; }
        public List<GetUserVM> Members { get; set; }
    }
}
