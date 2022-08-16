using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.CommunityVMs;
using ForumMVC.ViewModels.HomeVMs;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
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

            try
            {
                if(User.Identity.IsAuthenticated)
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                    GetUserCardVM userVM = new GetUserCardVM();

                    userVM.Username = user.UserName;
                    userVM.FullName = user.Name + " " + user.Surname;

                    List<UserImage> userImages = await _userImageService.GetAllByUserId(user.Id);

                    foreach (UserImage userImage in userImages)
                    {
                        if(userImage.Target == "profile")
                        {
                            userVM.ProfileImage = userImage.Image.Name;
                        }
                    }

                    Level level = await _levelService.Get(user.LevelId);

                    userVM.Level = level.Name;

                    homeVM.UserCard = userVM;


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

                        Level userLevel = await _levelService.Get(topic.Author.LevelId);

                        topicVM.AuthorLevel = level.Name;

                        List<UserImage> appUserImages = await _userImageService.GetAllByUserId(topic.AuthorId);

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
                else
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetTopicsForNoUser(int skip)
        {
            try
            {
                List<GetTopicVM> getTopicVMs = new List<GetTopicVM>();

                List<Topic> topics = await _topicService.GetAllPaginated(skip, 8);

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

                return PartialView("_TopicPartial", getTopicVMs);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message,
                });
            }
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
                return Json(new
                {
                    Status = 405,
                    Message = ex.Message
                });
            }
            return PartialView("_TopCommunitiesPartial", communityVM);
        }
    }
}
