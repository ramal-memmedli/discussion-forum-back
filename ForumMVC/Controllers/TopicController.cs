using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.AnswerVMs;
using ForumMVC.ViewModels.CommentVMs;
using ForumMVC.ViewModels.TopicVMs;
using ForumMVC.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
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

        public TopicController(ITopicService topicService, UserManager<AppUser> userManager, IUserImageService userImageService, ICategoryService categoryService, ILevelService levelService, IAnswerService answerService, ICommentService commentService, IAnswerVoteService answerVoteService)
        {
            _topicService = topicService;
            _userManager = userManager;
            _userImageService = userImageService;
            _categoryService = categoryService;
            _levelService = levelService;
            _answerService = answerService;
            _commentService = commentService;
            _answerVoteService = answerVoteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            GetTopicVM topicVM = new GetTopicVM();

            try
            {
                Topic topic = await _topicService.Get(id);

                topic.ViewCount = topic.ViewCount + 1;
                await _topicService.Update(topic);

                topicVM.Id = topic.Id;
                topicVM.Title = topic.Title;
                topicVM.Content = topic.Content;
                topicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                topicVM.AuthorUsername = topic.Author.UserName;

                List<UserImage> userImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                foreach (UserImage userImage in userImages)
                {
                    if(userImage.Target == "profile")
                    {
                        topicVM.AuthorImage = userImage.Image.Name;
                    }
                }

                AppUser appUser = await _userManager.FindByIdAsync(topic.AuthorId);

                Level userLevel = await _levelService.Get(appUser.LevelId);

                topicVM.AuthorLevel = userLevel.Name;
                topicVM.ViewCount = topic.ViewCount;
                topicVM.CreateDate = topic.CreateDate;
                topicVM.UpdateDate = topic.UpdateDate;

                topicVM.AnswerCount = await _answerService.GetTotalCountByTopicId(topic.Id);

                topicVM.TopicCategory = new GetTopicCategoryVM
                {
                    Id = topic.CategoryId,
                    Name = topic.Category.Name
                };

                List<Answer> answers = await _answerService.GetAllByTopicId(topic.Id);

                List<GetAnswerVM> getAnswersVM = new List<GetAnswerVM>();

                foreach (Answer answer in answers)
                {
                    GetAnswerVM answerVM = new GetAnswerVM();

                    answerVM.Id = answer.Id;
                    answerVM.Content = answer.Content;
                    answerVM.CreateDate = answer.CreateDate;
                    answerVM.AuthorFullname = answer.AppUser.Name + " " + answer.AppUser.Surname;
                    answerVM.AuthorUsername = answer.AppUser.UserName;

                    Level level = await _levelService.Get(answer.AppUser.LevelId);

                    answerVM.AuthorLevel = level.Name;

                    List<UserImage> answerUserImages = await _userImageService.GetAllByUserId(topic.AuthorId);

                    foreach (UserImage answerUserImage in answerUserImages)
                    {
                        if (answerUserImage.Target == "profile")
                        {
                            answerVM.AuthorImage = answerUserImage.Image.Name;
                        }
                    }

                    

                    bool isVotedByYou = false;
                    string isUpVote = "";
                    int upVotes = 0;
                    int downVotes = 0;

                    foreach (AnswerVote vote in answer.AnswerVotes)
                    {
                        if(User.Identity.IsAuthenticated)
                        {
                            AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                            if (vote.AppUserId == you.Id)
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
                        }
                        

                        if(vote.IsUpVote)
                        {
                            upVotes = upVotes + 1;
                        }
                        else
                        {
                            downVotes = downVotes + 1;
                        }
                    }

                    if(downVotes > upVotes)
                    {
                        answerVM.VoteCount = 0;
                    }
                    else
                    {
                        answerVM.VoteCount = upVotes - downVotes;
                    }

                    answerVM.IsVotedByYou = isVotedByYou;
                    answerVM.YourVote = isUpVote;

                    List<GetCommentVM> commentVMs = new List<GetCommentVM>();

                    List<Comment> comments = await _commentService.GetAllByAnswerId(answer.Id);

                    foreach (Comment comment in comments)
                    {
                        GetCommentVM getCommentVM = new GetCommentVM();

                        getCommentVM.Id = comment.Id;
                        getCommentVM.Content = comment.Content;
                        getCommentVM.CreateDate = comment.CreateDate;
                        getCommentVM.UpdateDate = comment.UpdateDate;
                        getCommentVM.AuthorUsername = comment.AppUser.UserName;
                        getCommentVM.AuthorFullname = comment.AppUser.Name + " " + comment.AppUser.Surname;

                        List<UserImage> commentUserImages = await _userImageService.GetAllByUserId(comment.AppUser.Id);

                        foreach (UserImage commentUserImage in commentUserImages)
                        {
                            if (commentUserImage.Target == "profile")
                            {
                                getCommentVM.AuthorImage = commentUserImage.Image.Name;
                            }
                        }
                        commentVMs.Add(getCommentVM);

                    }
                    answerVM.CommentCount = commentVMs.Count;
                    answerVM.Comments = commentVMs;

                    getAnswersVM.Add(answerVM);

                }

                topicVM.Answers = getAnswersVM;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 405,
                    Message = ex.Message
                });
            }

            return View(topicVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await GetCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create(CreateTopicVM topicVM)
        {
            ViewData["Categories"] = await GetCategories();


            if (!ModelState.IsValid)
            {
                return View(topicVM);
            }

            Topic topic = new Topic();

            topic.Title = topicVM.Title;
            topic.Content = topicVM.Content;
            topic.CategoryId = topicVM.CategoryId;

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            topic.AuthorId = user.Id;

            try
            {
                await _topicService.Create(topic);
                return RedirectToAction(actionName: "index", controllerName: "home");
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 405,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpVote(int id)
        {
            try
            {
                Answer answer = await _answerService.Get(id);

                Topic topic = await _topicService.Get(answer.TopicId);

                AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (AnswerVote vote in answer.AnswerVotes)
                {
                    if (vote.AppUserId == you.Id && vote.IsUpVote)
                    {
                        return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
                    }else if(vote.AppUserId == you.Id && !vote.IsUpVote)
                    {
                        vote.IsUpVote = true;
                        await _answerVoteService.Update(vote);

                        return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
                    }
                }

                AnswerVote answerVote = new AnswerVote();
                answerVote.AnswerId = answer.Id;
                answerVote.AppUserId = you.Id;
                answerVote.IsUpVote = true;

                await _answerVoteService.Create(answerVote);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DownVote(int id)
        {
            try
            {
                Answer answer = await _answerService.Get(id);

                Topic topic = await _topicService.Get(answer.TopicId);

                AppUser you = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (AnswerVote vote in answer.AnswerVotes)
                {
                    if (vote.AppUserId == you.Id && !vote.IsUpVote)
                    {
                        return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
                    }
                    else if (vote.AppUserId == you.Id && vote.IsUpVote)
                    {
                        vote.IsUpVote = false;
                        await _answerVoteService.Update(vote);

                        return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
                    }
                }

                AnswerVote answerVote = new AnswerVote();
                answerVote.AnswerId = answer.Id;
                answerVote.AppUserId = you.Id;
                answerVote.IsUpVote = false;

                await _answerVoteService.Create(answerVote);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { topic.Id });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult PostAnswer(int id)
        {
            ViewData["TopicId"] = id;
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

                Answer answer = new Answer();
                answer.TopicId = topic.Id;
                answer.Content = answerVM.Content;

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                answer.AppUserId = user.Id;

                await _answerService.Create(answer);

                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = topic.Id });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message
                });
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostComment(int id, string comment) 
        {
                Answer answer = await _answerService.Get(id);

                Comment newComment = new Comment();
                newComment.AnswerId = id;
                newComment.Content = comment;

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                if(User.Identity.IsAuthenticated && answer.AppUserId == user.Id)
                {
                    newComment.AppUserId = user.Id;
                    await _commentService.Create(newComment);
                }
                return RedirectToAction(actionName: "index", controllerName: "topic", new { id = answer.TopicId });

        }

        private async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _categoryService.GetAll();
            return categories;
        }
    }
}
