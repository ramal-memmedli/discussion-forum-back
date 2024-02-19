using System.ComponentModel.DataAnnotations;

namespace CommuPoint.Core.Application.ViewModels
{
    public class PostAnswerVM
    {
        [Required]
        public string Content { get; set; }
        public int TopicId { get; set; }

    }
}
