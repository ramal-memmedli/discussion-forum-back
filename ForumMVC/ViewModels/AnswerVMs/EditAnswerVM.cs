using DataAccessLayer.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.AnswerVMs
{
    public class EditAnswerVM
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int TopicId { get; set; }
    }
}
