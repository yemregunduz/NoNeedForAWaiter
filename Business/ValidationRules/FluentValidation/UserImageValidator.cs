using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserImageValidator : AbstractValidator<UserImage>
    {
        public UserImageValidator()
        {
            RuleFor(u => u.UserId)
                .NotNull().WithMessage(Messages.UserIdIsRequired)
                .GreaterThan(0).WithMessage(Messages.UserIdIsRequired);
            
        }
    }
}
