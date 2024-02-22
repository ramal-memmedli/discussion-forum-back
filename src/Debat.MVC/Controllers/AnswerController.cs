using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class AnswerController : Controller
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

        public AnswerController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService, IAnswerService answerService, ICommentService commentService, IAnswerVoteService answerVoteService, IBookmarkService bookmarkService)
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
        public IActionResult PostAnswer(int id)
        {
            ViewData["TopicId"] = id;

            ViewBag.Title = "Post answer";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> PostAnswer(PostAnswerVM answerVM)
        {
            try
            {
                Topic topic = await _topicService.Get(answerVM.TopicId);
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                Answer answer = new Answer();
                answer.TopicId = topic.Id;
                answer.Content = answerVM.Content;
                answer.AppUserId = user.Id;

                await _answerService.Create(answer);

                user.Point += 100;

                await _userManager.UpdateAsync(user);

                await _levelService.UpgradeUserLevel(user);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = topic.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> EditAnswer(int id)
        {
            ViewBag.Title = "Edit answer";

            try
            {
                Answer answer = await _answerService.Get(id);

                if (!await IsSignedUserAuthor(answer.AppUserId))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                EditAnswerVM answerVM = new()
                {
                    Id = answer.Id,
                    Content = answer.Content,
                    TopicId = answer.TopicId
                };

                return View(answerVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> EditAnswer(int id, EditAnswerVM answerVM)
        {
            if (!ModelState.IsValid)
                return View(answerVM);

            try
            {
                Answer answer = await _answerService.Get(id);

                if (await IsSignedUserAuthor(answer.AppUserId))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                answer.Content = answerVM.Content;

                await _answerService.Update(answer);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = answer.TopicId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                Answer answer = await _answerService.Get(id);

                if (await IsSignedUserAuthor(answer.AppUserId))
                    await _answerService.Delete(answer.Id);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = answer.TopicId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UseVote(int id, bool usedVote)
        {
            try
            {
                Answer answer = await _answerService.Get(id);

                AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (AnswerVote vote in answer.AnswerVotes)
                {
                    if (vote.AppUserId == you.Id)
                    {
                        vote.IsUpVote = usedVote;
                    }

                    return RedirectToAction(actionName: "index", controllerName: "topic", new { answer.TopicId });
                }

                AnswerVote answerVote = new()
                {
                    AnswerId = answer.Id,
                    AppUserId = you.Id,
                    IsUpVote = true
                };

                await _answerVoteService.Create(answerVote);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { answer.TopicId });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }


        // Copied temporarily
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
