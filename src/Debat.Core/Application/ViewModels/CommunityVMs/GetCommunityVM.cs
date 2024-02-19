namespace Debat.Core.Application.ViewModels
{
    public class GetCommunityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Point { get; set; }
        public bool AreYouAdmin { get; set; }
        public string ProfileImage { get; set; }
        public string BannerImage { get; set; }
        public List<GetTopicVM> Topics { get; set; }
        public List<GetUserVM> Members { get; set; }
    }
}
