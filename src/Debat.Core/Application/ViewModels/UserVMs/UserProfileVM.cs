namespace Debat.Core.Application.ViewModels
{
    public class UserProfileVM
    {
        public GetUserVM User { get; set; }
        public List<GetTopicVM> Topics { get; set; }
    }
}
