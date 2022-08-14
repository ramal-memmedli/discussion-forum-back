using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.TopicVMs
{
    public class CreateTopicVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
