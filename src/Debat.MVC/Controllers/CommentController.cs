using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class CommentController : Controller
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

        public CommentController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService, IAnswerService answerService, ICommentService commentService, IAnswerVoteService answerVoteService, IBookmarkService bookmarkService)
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

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostComment(int id, string? comment)
        {
            try
            {
                Answer answer = await _answerService.Get(id);

                Comment newComment = new Comment();
                newComment.AnswerId = id;
                newComment.Content = comment;

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (User.Identity.IsAuthenticated)
                {
                    newComment.AppUserId = user.Id;
                    await _commentService.Create(newComment);

                    user.Point += 50;

                    await _userManager.UpdateAsync(user);
                    await _levelService.UpgradeUserLevel(user);
                }
                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = answer.TopicId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                Comment comment = await _commentService.Get(id);

                Answer answer = await _answerService.Get(comment.AnswerId);

                if (!await IsSignedUserAuthor(comment.AppUserId))
                    return RedirectToAction(actionName: "index", controllerName: "topic", new { id = comment.AnswerId });


                await _commentService.Delete(comment.Id);
                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = comment.AnswerId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        // Copied temporarily
        private async Task<bool> IsSignedUserAuthor(string? authorId)
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
