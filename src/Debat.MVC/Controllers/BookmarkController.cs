using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserImageService _userImageService;
        private readonly ICategoryService _categoryService;
        private readonly ILevelService _levelService;
        private readonly IAnswerService _answerService;
        private readonly ICommentService _commentService;
        private readonly IAnswerVoteService _answerVoteService;
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService, IAnswerService answerService, ICommentService commentService, IAnswerVoteService answerVoteService, IBookmarkService bookmarkService)
        {
            _topicService = topicService;
            _userManager = userManager;
            _userImageService = userImageService;
            _categoryService = categoryService;
            _levelService = levelService;
            _answerService = answerService;
            _commentService = commentService;
            _answerVoteService = answerVoteService;
            _bookmarkService = bookmarkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> AddToBookmarks(int id)
        {
            try
            {
                Topic topic = await _topicService.Get(id);

                if (await IsInBookmarks(topic.Id))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                await _bookmarkService.Create(new UserBookmark()
                {
                    AppUserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id,
                    TopicId = topic.Id
                });

                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = topic.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> RemoveFromBookmarks(int id)
        {
            try
            {
                if (!await IsInBookmarks(id))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                await _bookmarkService.Delete(id);

                return RedirectToAction(actionName: "bookmarks", controllerName: "user", new { id = await _userManager.FindByNameAsync(User.Identity.Name) });

            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        //Copied temporarily
        private async Task<bool> IsInBookmarks(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return false;

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            List<UserBookmark> bookmarks = await _bookmarkService.GetAllByUserId(user.Id);

            bool isIn = false;

            foreach (UserBookmark bookmark in bookmarks)
            {
                if (bookmark.TopicId == id)
                {
                    isIn = true;
                    break;
                }
            }

            return isIn;
        }
        //Copied temporarily
        private async Task<bool> IsSignedUserAuthor(string authorId)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser signedUser = await _userManager.FindByNameAsync(User.Identity.Name);

                if (authorId == signedUser.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
