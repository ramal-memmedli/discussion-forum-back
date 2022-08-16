using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.AnswerVMs
{
    public class PostAnswerVM
    {
        [Required]
        public string Content { get; set; }
        public int TopicId { get; set; }

    }
}
