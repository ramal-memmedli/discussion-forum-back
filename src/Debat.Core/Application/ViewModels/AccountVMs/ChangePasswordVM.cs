using System.ComponentModel.DataAnnotations;

namespace Debat.Core.Application.ViewModels
{
    public class ChangePasswordVM
    {
        [Required, DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), MaxLength(64)]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), MaxLength(64), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
