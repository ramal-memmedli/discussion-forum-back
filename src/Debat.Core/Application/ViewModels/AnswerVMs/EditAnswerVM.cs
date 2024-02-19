using System.ComponentModel.DataAnnotations;

namespace Debat.Core.Application.ViewModels
{
    public class EditAnswerVM
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int TopicId { get; set; }
    }
}
