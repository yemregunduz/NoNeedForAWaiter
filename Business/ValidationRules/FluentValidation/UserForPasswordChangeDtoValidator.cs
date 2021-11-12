using Business.Constants;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForPasswordChangeDtoValidator:AbstractValidator<UserForPasswordChangeDto>
    {
        public UserForPasswordChangeDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(Messages.EmailIsRequired)
                .EmailAddress().WithMessage(Messages.EmailIsNotValid);
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(Messages.PasswordIsRequired)
                .Must(IsPasswordValid).WithMessage(Messages.PasswordIsNotValid);
        }
        private bool IsPasswordValid(string password)
        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@!%*?+#&'()[=\"€])[A-Za-z\\d$@!%*?+#&'()[=\"€']{8,}");
            return regex.IsMatch(password);
        }
    }
}
