using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage(Messages.FirstNameIsRequired)
                .MaximumLength(50).WithMessage(Messages.FirstNameIsNotValid);
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage(Messages.LastNameIsRequired)
                .MaximumLength(50).WithMessage(Messages.LastNameIsNotValid);
            RuleFor(u => u.RestaurantId)
                .NotNull().WithMessage(Messages.RestaurantIsRequired);
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(Messages.EmailIsRequired)
                .EmailAddress().WithMessage(Messages.EmailIsNotValid);
        }
        
    }
}
