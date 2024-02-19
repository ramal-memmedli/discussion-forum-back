using Debat.Core.Application.DTOs.Account;
using FluentValidation;

namespace Debat.Core.Application.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator() 
        {
            RuleFor(ldto => ldto.Username).NotNull().NotEmpty().MinimumLength(6).MaximumLength(64);
            RuleFor(ldto => ldto.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(64);
        }
    }
}
