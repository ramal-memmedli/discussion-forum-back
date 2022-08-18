using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.AccountVMs
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
