using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.CommunityVMs;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
{
    public class CommunityController : Controller
    {
        private readonly ICommunityService _communityService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITopicService _topicService;
        private readonly IImageService _imageService;

        public CommunityController(ICommunityService communityService, UserManager<AppUser> userManager, ITopicService topicService, IImageService imageService)
        {
            _communityService = communityService;
            _userManager = userManager;
            _topicService = topicService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index(int id)
        {
            GetCommunityVM communityVM = new GetCommunityVM();

            try
            {
                Community community = await _communityService.Get(id);

                communityVM.Id = community.Id;
                communityVM.Name = community.Name;
                communityVM.About = community.About;
                communityVM.Point = community.Point;
                communityVM.AreYouAdmin = false;

                AppUser you = new AppUser();

                if (User.Identity.IsAuthenticated)
                {
                    you = await _userManager.FindByNameAsync(User.Identity.Name);

                }


                foreach (CommunityMember communityMember in community.CommunityMembers)
                {
                    AppUser user = await _userManager.FindByIdAsync(communityMember.AppUserId);

                    if(communityMember.AppUserId == you.Id && communityMember.position == "admin")
                    {
                        communityVM.AreYouAdmin = true;
                    }

                    communityVM.Members.Add(new GetUserVM
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Username = user.UserName
                    });
                }

                foreach(CommunityImage communityImage in community.CommunityImages)
                {
                    Image image = await _imageService.Get(communityImage.ImageId);

                    if(communityImage.Target == "banner")
                    {
                        communityVM.BannerImage = image.Name;
                    }
                    if(communityImage.Target == "profile")
                    {
                        communityVM.ProfileImage = image.Name;
                    }
                }


            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }

            return View(communityVM);
        }
    }
}
