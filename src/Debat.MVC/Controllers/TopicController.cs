using Debat.Core.Application.Mappings;
using Debat.Core.Application.Services;
using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Debat.MVC.Controllers
{
    public class TopicController : Controller
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

        public TopicController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService, IAnswerService answerService, ICommentService commentService, IAnswerVoteService answerVoteService, IBookmarkService bookmarkService)
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

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            GetTopicVM topicVM = new GetTopicVM();

            try
            {
                Topic topic = await _topicService.Get(id);

                ViewBag.Title = "Topic - " + topic.Title;

                List<Answer> answers = await _answerService.GetAllByTopicId(topic.Id);

                #region Answer

                List<GetAnswerVM> getAnswersVM = new List<GetAnswerVM>();

                foreach (Answer answer in answers)
                {
                    GetAnswerVM answerVM = new GetAnswerVM();

                    bool isVotedByYou = false;
                    string isUpVote = "";
                    int upVotes = 0;
                    int downVotes = 0;

                    foreach (AnswerVote vote in answer.AnswerVotes)
                    {
                        if (await IsSignedUserAuthor(vote.AppUserId))
                        {
                            isVotedByYou = true;

                            if (vote.IsUpVote)
                            {
                                isUpVote = "up";
                            }
                            else
                            {
                                isUpVote = "down";
                            }
                        }


                        if (vote.IsUpVote)
                        {
                            upVotes++;
                        }
                        else
                        {
                            downVotes++;
                        }
                    }

                    #region Comment

                    List<GetCommentVM> commentVMs = new List<GetCommentVM>();

                    List<Comment> comments = await _commentService.GetAllByAnswerId(answer.Id);

                    foreach (Comment comment in comments)
                    {
                        GetCommentVM getCommentVM = new GetCommentVM();

                        getCommentVM = comment.MapToVM((await _userImageService.GetUsersProfileImage(comment.AppUserId)).Name,
                                                       await IsSignedUserAuthor(comment.AppUserId));

                        commentVMs.Add(getCommentVM);
                    }

                    #endregion

                    answerVM = answer.MapToVM((await _userImageService.GetUsersProfileImage(answer.AppUserId)).Name,
                                              (await _levelService.Get(answer.AppUser.LevelId)).Name,
                                              await IsSignedUserAuthor(answer.AppUserId),
                                              isVotedByYou,
                                              isUpVote,
                                              upVotes - downVotes,
                                              commentVMs);

                    getAnswersVM.Add(answerVM);

                    #endregion
                }

                topicVM = topic.MapToVM(await IsInBookmarks(topic.Id),
                                        await IsSignedUserAuthor(topic.AuthorId),
                                        (await _userImageService.GetUsersProfileImage(topic.AuthorId)).Name,
                                        (await _levelService.Get(topic.Author.LevelId)).Name,
                                        getAnswersVM);

                topic.ViewCount++;
                await _topicService.Update(topic);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }

            return View(topicVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await GetCategories();
            ViewBag.Title = "New topic";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create(CreateTopicVM topicVM)
        {
            ViewData["Categories"] = await GetCategories();

            if (!ModelState.IsValid)
                return View(topicVM);

            try
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                Topic topic = topicVM.MapToModel(user.Id);

                await _topicService.Create(topic);

                user.Point += 100;

                await _userManager.UpdateAsync(user);

                await _levelService.UpgradeUserLevel(user);

                return RedirectToAction(actionName: "index", controllerName: "home");
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = await GetCategories();
            ViewBag.Title = "Edit topic";

            try
            {
                AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                Topic topic = await _topicService.Get(id);

                EditTopicVM topicVM = new EditTopicVM();

                if (!await IsSignedUserAuthor(topic.AuthorId))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                topicVM.Id = topic.Id;
                topicVM.Title = topic.Title;
                topicVM.Content = topic.Content;
                topicVM.CategoryId = topic.CategoryId;

                return View(topicVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id, EditTopicVM topicVM)
        {
            ViewData["Categories"] = await GetCategories();

            if (!ModelState.IsValid)
            {
                return View(topicVM);
            }

            try
            {
                AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                Topic topic = await _topicService.Get(id);

                if (!await IsSignedUserAuthor(topic.AuthorId))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");


                topic.Title = topicVM.Title;
                topic.Content = topicVM.Content;
                topic.CategoryId = topicVM.CategoryId;

                await _topicService.Update(topic);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");

            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Topic topic = await _topicService.Get(id);

                if (!await IsSignedUserAuthor(topic.AuthorId))
                    return RedirectToAction(actionName: "notfound", controllerName: "home");

                await _topicService.Delete(id);
                return RedirectToAction(controllerName: "home", actionName: "index");
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "notfound", controllerName: "home");
            }
        }

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

        private async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _categoryService.GetAll();
            return categories;
        }

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
