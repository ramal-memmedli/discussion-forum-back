using BusinessLayer.Services;
using DataAccessLayer.Models;
using ForumMVC.ViewModels.TopicVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumMVC.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            GetTopicVM topicVM = new GetTopicVM();
            try
            {
                Topic topic = await _topicService.Get(id);

                topicVM.Id = topic.Id;
                topicVM.Title = topic.Title;
                topicVM.Content = topic.Content;
                topicVM.AuthorFullName = topic.Author.Name + " " + topic.Author.Surname;
                topicVM.AuthorUsername = topic.Author.UserName;
                topicVM.ViewCount = topic.ViewCount;
                topicVM.CreateDate = topic.CreateDate;
                topicVM.UpdateDate = topic.UpdateDate;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 404,
                    Message = ex.Message,
                });
            }

            return View(topicVM);
        }
    }
}
