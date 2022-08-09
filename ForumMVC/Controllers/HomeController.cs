using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
