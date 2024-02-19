using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Admin panel - Categories";

            try
            {
                List<Category> categories = await _categoryService.GetAll();

                return View(categories);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = "Edit category";

            try
            {
                Category category = await _categoryService.Get(id);

                return View(category);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            Category categoryDb = new Category();

            try
            {
                categoryDb = await _categoryService.Get(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            try
            {
                categoryDb.Name = category.Name;

                await _categoryService.Update(categoryDb);

                return RedirectToAction(controllerName: "categories", actionName: "index");
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "New category";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            Category categoryDb = new Category();

            try
            {
                categoryDb.Name = category.Name;

                await _categoryService.Create(categoryDb);

                return RedirectToAction(controllerName: "categories", actionName: "index");
            }
            catch (Exception)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }
    }
}
