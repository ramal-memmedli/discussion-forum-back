using ForumMVC.ViewModels.AnswerVMs;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.TopicVMs
{
    public class EditTopicVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
