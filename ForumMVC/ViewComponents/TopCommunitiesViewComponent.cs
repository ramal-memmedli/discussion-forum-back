using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.CommunityVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.ViewComponents
{
    public class TopCommunitiesViewComponent : ViewComponent
    {
        private readonly ICommunityService _communityService;
        private readonly IImageService _imageService;

        public TopCommunitiesViewComponent(ICommunityService communityService, IImageService imageService)
        {
            _communityService = communityService;
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
                return View("Default");
            }
            return View(model: communityVM);
        }
    }
}
