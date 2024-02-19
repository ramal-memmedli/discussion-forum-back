using System.ComponentModel.DataAnnotations;

namespace CommuPoint.Core.Application.ViewModels
{
    public class LoginVM
    {
        [Required, MaxLength(64)]
        public string Username { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
