using System.ComponentModel.DataAnnotations;

namespace Debat.Core.Application.ViewModels
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
