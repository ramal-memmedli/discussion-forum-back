using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.CommunityVMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;

namespace ForumMVC.ViewComponents
{
    public class TopUsersViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //List<GetUserCardVM> userVMs = new List<GetUserCardVM>();

            //try
            //{
            //    List<AppUser> users = (List<AppUser>)await _userManager.GetUsersInRoleAsync("User");

            //    foreach (Community community in communities)
            //    {
            //        string profileImage = "";
            //        string bannerImage = "";

            //        foreach (CommunityImage communityImage in community.CommunityImages)
            //        {
            //            Image image = await _imageService.Get(communityImage.ImageId);

            //            if (communityImage.Target == "banner")
            //            {
            //                bannerImage = image.Name;
            //            }
            //            if (communityImage.Target == "profile")
            //            {
            //                profileImage = image.Name;
            //            }
            //        }

            //        communityVM.Add(new GetCommunityCardVM
            //        {
            //            Id = community.Id,
            //            Name = community.Name,
            //            ProfileImage = profileImage,
            //            BannerImage = bannerImage,
            //            MemberCount = community.CommunityMembers.Count,
            //        });
            //    }

            //    return View(model: communityVM);
            //}
            //catch (Exception ex)
            //{
            //    return View("Error");
            //}

            return View();
        }
    }
}
