﻿using System.ComponentModel.DataAnnotations;

namespace Debat.Core.Application.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
