using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserImageService _userImageService;
        private readonly ILevelService _levelService;
        private readonly ITopicService _topicService;
        private readonly IAnswerService _answerService;
        private readonly ICommunityService _communityService;
        private readonly IImageService _imageService;

        public HomeController(UserManager<AppUser> userManager, IUserImageService userImageService, ILevelService levelService, ITopicService topicService, IAnswerService answerService, ICommunityService communityService, IImageService imageService)
        {
            _userManager = userManager;
            _userImageService = userImageService;
            _levelService = levelService;
            _topicService = topicService;
            _answerService = answerService;
            _communityService = communityService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();

            ViewBag.Title = "Forum - Home";

            try
            {

                List<GetTopicVM> getTopicVMs = new List<GetTopicVM>();

                List<Topic> topics = await _topicService.GetAllPaginated(1, 8);

                foreach (Topic topic in topics)
                {
                    GetTopicVM topicVM = new GetTopicVM();

                    topicVM.Id = topic.Id;
                    topicVM.Title = topic.Title;
                    topicVM.Content = topic.Content;
                    topicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                    topicVM.AuthorUsername = topic.Author.UserName;

                    Level level = await _levelService.Get(topic.Author.LevelId);

                    topicVM.AuthorLevel = level.Name;

                    List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                    foreach (UserImage userImage in userImages)
                    {
                        if (userImage.Target == "profile")
                        {
                            topicVM.AuthorImage = userImage.Image.Name;
                        }
                    }

                    topicVM.ViewCount = topic.ViewCount;
                    topicVM.CreateDate = topic.CreateDate;
                    topicVM.UpdateDate = topic.UpdateDate;

                    topicVM.AnswerCount = await _answerService.GetTotalCountByTopicId(topic.Id);

                    topicVM.TopicCategory = new GetTopicCategoryVM
                    {
                        Id = topic.CategoryId,
                        Name = topic.Category.Name
                    };

                    getTopicVMs.Add(topicVM);
                }

                homeVM.Topics = getTopicVMs;

                return View(homeVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }

            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetTopCommunities()
        {
            List<GetCommunityCardVM> communityVM = new List<GetCommunityCardVM>();

            try
            {
                List<Community> communities = await _communityService.GetAllDescOrdered(n => n.Point);

                foreach (Community community in communities)
                {
                    string profileImage = "";
                    string bannerImage = "";

                    foreach (CommunityImage communityImage in community.CommunityImages)
                    {
                        Image image = await _imageService.Get(communityImage.ImageId);

                        if (communityImage.Target == "banner")
                        {
                            bannerImage = image.Name;
                        }
                        if (communityImage.Target == "profile")
                        {
                            profileImage = image.Name;
                        }
                    }

                    communityVM.Add(new GetCommunityCardVM
                    {
                        Id = community.Id,
                        Name = community.Name,
                        ProfileImage = profileImage,
                        BannerImage = bannerImage,
                        MemberCount = community.CommunityMembers.Count,
                    });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
            return PartialView("_TopCommunitiesPartial", communityVM);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string content)
        {
            ViewBag.Title = "Search results";

            try
            {
                List<Topic> topics = await _topicService.GetAllBySearch(content);

                List<GetTopicVM> getTopicVMs = new List<GetTopicVM>();

                foreach (Topic topic in topics)
                {
                    GetTopicVM topicVM = new GetTopicVM();

                    topicVM.Id = topic.Id;
                    topicVM.Title = topic.Title;
                    topicVM.Content = topic.Content;
                    topicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                    topicVM.AuthorUsername = topic.Author.UserName;

                    Level level = await _levelService.Get(topic.Author.LevelId);

                    topicVM.AuthorLevel = level.Name;

                    List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                    foreach (UserImage userImage in userImages)
                    {
                        if (userImage.Target == "profile")
                        {
                            topicVM.AuthorImage = userImage.Image.Name;
                        }
                    }

                    topicVM.ViewCount = topic.ViewCount;
                    topicVM.CreateDate = topic.CreateDate;
                    topicVM.UpdateDate = topic.UpdateDate;

                    topicVM.TopicCategory = new GetTopicCategoryVM
                    {
                        Id = topic.CategoryId,
                        Name = topic.Category.Name
                    };

                    getTopicVMs.Add(topicVM);
                }

                return View(getTopicVMs);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            ViewBag.Title = "Page not found";

            return View();
        }
    }
}
