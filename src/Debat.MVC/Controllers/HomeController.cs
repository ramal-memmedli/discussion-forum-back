using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class HomeController(UserManager<AppUser> userManager,
                                IUserImageService userImageService,
                                ILevelService levelService,
                                ITopicService topicService,
                                IAnswerService answerService,
                                ICommunityService communityService,
                                IImageService imageService) : Controller
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IUserImageService _userImageService = userImageService;
        private readonly ILevelService _levelService = levelService;
        private readonly ITopicService _topicService = topicService;
        private readonly IAnswerService _answerService = answerService;
        private readonly ICommunityService _communityService = communityService;
        private readonly IImageService _imageService = imageService;

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
                    topicVM.AuthorLevel = (await _levelService.Get(topic.Author.LevelId)).Name;
                    topicVM.AuthorImage = (await _userImageService.GetUsersProfileImage(topic.AuthorId)).Name;
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
                    topicVM.AuthorLevel = (await _levelService.Get(topic.Author.LevelId)).Name;
                    topicVM.AuthorImage = (await _userImageService.GetUsersProfileImage(topic.AuthorId)).Name;
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
            catch (Exception)
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
