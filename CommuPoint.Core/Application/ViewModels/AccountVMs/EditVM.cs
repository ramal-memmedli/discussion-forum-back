using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CommuPoint.Core.Application.ViewModels
{
    public class EditVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string About { get; set; }
        public IFormFile ProfileImage { get; set; }
        public IFormFile BannerImage { get; set; }
    }
}
