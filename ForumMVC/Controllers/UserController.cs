using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.CommunityVMs;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Common.Helpers.Enums;

namespace ForumMVC.Controllers
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

                GetUserVM userVM = new GetUserVM()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.UserName
                };

                ViewBag.Title = user.Name + " " + user.Surname;

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



                userProfile.User = userVM;
                userProfile.Topics = topicVMs;

                try
                {
                    topics = await _topicService.GetAllByAuthor(user.Id);
                    Level level = await _levelService.Get(user.LevelId);

                    foreach (Topic topic in topics)
                    {
                        GetTopicVM getTopicVM = new GetTopicVM();

                        getTopicVM.Id = topic.Id;
                        getTopicVM.Title = topic.Title;
                        getTopicVM.Content = topic.Content;
                        getTopicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                        getTopicVM.AuthorUsername = topic.Author.UserName;
                        getTopicVM.AuthorLevel = level.Name;


                        List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                        foreach (UserImage userImage in userImages)
                        {
                            if (userImage.Target == "profile")
                            {
                                getTopicVM.AuthorImage = userImage.Image.Name;
                            }
                        }

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

                    userProfile.User.TopicCount = topics.Count;
                }
                catch (Exception ex)
                {
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                }
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
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.Title = user.Name + " " + user.Surname + " - Bookmarks";

            try
            {
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


                List<UserBookmark> bookmarks = await _bookmarkService.GetAllByUserId(user.Id);

                List<GetTopicVM> topicVMs = new List<GetTopicVM>();

                UserProfileVM userProfile = new UserProfileVM();

                userProfile.User = userVM;
                userProfile.Topics = topicVMs;

                try
                {
                    foreach (UserBookmark bookmark in bookmarks)
                    {
                        Topic topic = await _topicService.Get(bookmark.TopicId);

                        Level level = await _levelService.Get(topic.Author.LevelId);

                        GetTopicVM getTopicVM = new GetTopicVM();

                        getTopicVM.Id = topic.Id;
                        getTopicVM.Title = topic.Title;
                        getTopicVM.Content = topic.Content;
                        getTopicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                        getTopicVM.AuthorUsername = topic.Author.UserName;
                        getTopicVM.AuthorLevel = level.Name;

                        List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                        foreach (UserImage userImage in userImages)
                        {
                            if (userImage.Target == "profile")
                            {
                                getTopicVM.AuthorImage = userImage.Image.Name;
                            }
                        }

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
                }
                catch (Exception ex)
                {
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                }
                return View(userProfile);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
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