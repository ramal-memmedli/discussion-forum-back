using System.ComponentModel.DataAnnotations;

namespace Debat.Core.Application.ViewModels
{
    public class ResetPasswordVM
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
