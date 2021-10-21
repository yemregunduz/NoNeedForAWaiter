using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RestaurantValidator:AbstractValidator<Restaurant>
    {
        public RestaurantValidator()
        {
            RuleFor(r => r.TaxNumber)
                .NotNull().WithMessage(Messages.TaxNumberIsRequired);
            RuleFor(r => r.RestaurantName)
                .MaximumLength(100).WithMessage(Messages.RestaurantNameIsNotValid);
        }

    }

}
