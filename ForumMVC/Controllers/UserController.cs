using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITopicService _topicService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, ITopicService topicService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _topicService = topicService;
        }

        public async Task<IActionResult> Index(string id)
        {
            AppUser user = await _userManager.FindByNameAsync(id);

            GetUserVM userVM = new GetUserVM()
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName
            };

            List<GetTopicVM> topicVMs = new List<GetTopicVM>();

            List<Topic> topics = new List<Topic>();

            try
            {
                topics = await _topicService.GetAllByAuthor(user.Id);

                foreach (Topic topic in topics)
                {
                    topicVMs.Add(new GetTopicVM
                    {
                        Id = topic.Id,
                        Title = topic.Title,
                        Content = topic.Content,
                        AuthorFullName = topic.Author.Name + " " + topic.Author.Surname,
                        AuthorUsername = topic.Author.UserName,
                        ViewCount = topic.ViewCount,
                        CreateDate = topic.CreateDate,
                        UpdateDate = topic.UpdateDate,
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message,
                });
            }

            UserProfileVM userProfile = new UserProfileVM();

            userProfile.User = userVM;
            userProfile.Topics = topicVMs;

            return View(userProfile);
        }
    }
}
