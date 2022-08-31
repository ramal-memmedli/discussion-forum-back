using System.ComponentModel.DataAnnotations;

namespace ForumMVC.ViewModels.AccountVMs
{
    public class ForgotPasswordVM
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
