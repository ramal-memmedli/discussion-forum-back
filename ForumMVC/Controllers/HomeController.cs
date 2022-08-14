using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.HomeVMs;
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

        public HomeController(UserManager<AppUser> userManager, IUserImageService userImageService, ILevelService levelService)
        {
            _userManager = userManager;
            _userImageService = userImageService;
            _levelService = levelService;
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
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return View(homeVM);
        }
    }
}
