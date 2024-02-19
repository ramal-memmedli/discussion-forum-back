using System.ComponentModel.DataAnnotations;

namespace CommuPoint.Core.Application.ViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Required, MaxLength(128)]
        public string Surname { get; set; }
        [Required, MaxLength(64)]
        public string Username { get; set; }
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(256), DataType(DataType.EmailAddress), Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
