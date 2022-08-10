using DataAccessLayer.Models;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.ViewComponents
{
    public class TopUsersViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public TopUsersViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task<IActionResult> InvokeAsync()
        //{
        //    List<GetUserVM> userVMs = new List<GetUserVM>();

        //    try
        //    {
        //        List<AppUser> users = await _userManager.Get
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
