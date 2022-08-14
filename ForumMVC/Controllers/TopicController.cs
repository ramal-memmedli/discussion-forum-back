using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserImageService _userImageService;
        private readonly ICategoryService _categoryService;
        private readonly ILevelService _levelService;

        public TopicController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService)
        {
            _topicService = topicService;
            _userManager = userManager;
            _userImageService = userImageService;
            _categoryService = categoryService;
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            GetTopicVM topicVM = new GetTopicVM();

            try
            {
                Topic topic = await _topicService.Get(id);

                topic.ViewCount = topic.ViewCount + 1;
                await _topicService.Update(topic);

                topicVM.Id = topic.Id;
                topicVM.Title = topic.Title;
                topicVM.Content = topic.Content;
                topicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                topicVM.AuthorUsername = topic.Author.UserName;

                List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                foreach (UserImage userImage in userImages)
                {
                    if(userImage.Target == "profile")
                    {
                        topicVM.AuthorImage = userImage.Image.Name;
                    }
                }

                AppUser appUser = await _userManager.FindByIdAsync(topic.AuthorId);

                Level userLevel = await _levelService.Get(appUser.LevelId);

                topicVM.AuthorLevel = userLevel.Name;
                topicVM.ViewCount = topic.ViewCount;
                topicVM.CreateDate = topic.CreateDate;
                topicVM.UpdateDate = topic.UpdateDate;
                topicVM.TopicCategory = new GetTopicCategoryVM
                {
                    Id = topic.CategoryId,
                    Name = topic.Category.Name
                };
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 405,
                    Message = ex.Message
                });
            }

            return View(topicVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await GetCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTopicVM topicVM)
        {
            if(!ModelState.IsValid)
            {
                return View(topicVM);
            }

            Topic topic = new Topic();

            topic.Title = topicVM.Title;
            topic.Content = topicVM.Content;
            topic.CategoryId = topicVM.CategoryId;

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            topic.AuthorId = user.Id;

            try
            {
                await _topicService.Create(topic);
                return RedirectToAction(actionName: "index", controllerName: "home");
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 405,
                    Message = ex.Message
                });
            }
        }

        private async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _categoryService.GetAll();
            return categories;
        }
    }
}
