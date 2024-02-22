using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITopicService _topicService;
        private readonly IUserImageService _userImageService;
        private readonly ILevelService _levelService;
        private readonly IBookmarkService _bookmarkService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, ITopicService topicService, IUserImageService userImageService, ILevelService levelService, IBookmarkService bookmarkService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _topicService = topicService;
            _userImageService = userImageService;
            _levelService = levelService;
            _bookmarkService = bookmarkService;
        }

        public async Task<IActionResult> Index(string id)
        {
            List<GetTopicVM> topicVMs = new List<GetTopicVM>();

            List<Topic> topics = new List<Topic>();

            UserProfileVM userProfile = new UserProfileVM();

            try
            {
                AppUser user = await _userManager.FindByNameAsync(id);

                ViewBag.Title = user.Name + " " + user.Surname;

                Image profileImage = await _userImageService.GetUsersProfileImage(user.Id);
                Image bannerImage = await _userImageService.GetUsersProfileBanner(user.Id);

                Level level = await _levelService.Get(user.LevelId);

                GetUserVM userVM = new GetUserVM()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.UserName,
                    ProfileImage = profileImage.Name,
                    BannerImage = bannerImage.Name,
                    Level = level.Name
                };
                userProfile.User = userVM;



                topics = await _topicService.GetAllByAuthor(user.Id);

                foreach (Topic topic in topics)
                {
                    GetTopicVM getTopicVM = new GetTopicVM();

                    getTopicVM.Id = topic.Id;
                    getTopicVM.Title = topic.Title;
                    getTopicVM.Content = topic.Content;
                    getTopicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                    getTopicVM.AuthorUsername = topic.Author.UserName;
                    getTopicVM.AuthorLevel = level.Name;
                    getTopicVM.AuthorImage = profileImage.Name;
                    getTopicVM.ViewCount = topic.ViewCount;
                    getTopicVM.CreateDate = topic.CreateDate;
                    getTopicVM.UpdateDate = topic.UpdateDate;

                    getTopicVM.TopicCategory = new GetTopicCategoryVM
                    {
                        Id = topic.CategoryId,
                        Name = topic.Category.Name
                    };

                    topicVMs.Add(getTopicVM);
                }

                userProfile.Topics = topicVMs;

                userProfile.User.TopicCount = topics.Count;
            }
            catch (Exception)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            return View(userProfile);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Bookmarks()
        {
            UserProfileVM userProfile = new UserProfileVM();

            try
            {
                List<GetTopicVM> topicVMs = new List<GetTopicVM>();

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                ViewBag.Title = user.Name + " " + user.Surname + " - Bookmarks";

                Image profileImage = await _userImageService.GetUsersProfileImage(user.Id);
                Image bannerImage = await _userImageService.GetUsersProfileBanner(user.Id);

                Level level = await _levelService.Get(user.LevelId);

                List<UserBookmark> bookmarks = await _bookmarkService.GetAllByUserId(user.Id);

                GetUserVM userVM = new GetUserVM()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.UserName,
                    ProfileImage = profileImage.Name,
                    BannerImage = bannerImage.Name,
                    Level = level.Name,
                };

                foreach (UserBookmark bookmark in bookmarks)
                {
                    Topic topic = await _topicService.Get(bookmark.TopicId);

                    Image authorsProfileImage = await _userImageService.GetUsersProfileImage(user.Id);

                    Level authorLevel = await _levelService.Get(topic.Author.LevelId);

                    GetTopicVM getTopicVM = new GetTopicVM();

                    getTopicVM.Id = topic.Id;
                    getTopicVM.Title = topic.Title;
                    getTopicVM.Content = topic.Content;
                    getTopicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                    getTopicVM.AuthorUsername = topic.Author.UserName;
                    getTopicVM.AuthorLevel = level.Name;
                    getTopicVM.AuthorImage = authorsProfileImage.Name;
                    getTopicVM.ViewCount = topic.ViewCount;
                    getTopicVM.CreateDate = topic.CreateDate;
                    getTopicVM.UpdateDate = topic.UpdateDate;

                    getTopicVM.TopicCategory = new GetTopicCategoryVM
                    {
                        Id = topic.CategoryId,
                        Name = topic.Category.Name
                    };

                    topicVMs.Add(getTopicVM);
                }

                userProfile.User = userVM;
                userProfile.Topics = topicVMs;
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            return View(userProfile);
        }

        [HttpGet]
        public async Task<IActionResult> About(string id)
        {

            try
            {
                AppUser user = await _userManager.FindByNameAsync(id);

                ViewBag.Title = user.Name + " " + user.Surname + " - About";

                GetUserVM userVM = new GetUserVM()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.UserName
                };


                try
                {
                    List<UserImage> userImages = await _userImageService.GetAllByUserId(user.Id);

                    foreach (UserImage userImage in userImages)
                    {
                        if (userImage.Target == "profile")
                        {
                            userVM.ProfileImage = userImage.Image.Name;
                        }
                        if (userImage.Target == "banner")
                        {
                            userVM.BannerImage = userImage.Image.Name;
                        }
                    }

                    Level level = await _levelService.Get(user.LevelId);

                    userVM.Level = level.Name;
                }
                catch (Exception ex)
                {
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                }

                AboutUserVM aboutUserVM = new AboutUserVM();

                aboutUserVM.User = userVM;
                aboutUserVM.About = user.About;

                return View(aboutUserVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }
    }
}