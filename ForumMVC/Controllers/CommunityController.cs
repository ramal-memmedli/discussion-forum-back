using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
