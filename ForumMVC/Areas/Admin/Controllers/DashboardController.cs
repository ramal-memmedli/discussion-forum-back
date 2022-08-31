using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Common.Helpers.Enums;

namespace ForumMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin panel - Dashboard";

            return View();
        }
    }
}
