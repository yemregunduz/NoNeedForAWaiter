using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TableValidator:AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(t => t.RestaurantId)
                .NotNull().WithMessage(Messages.RestaurantIdIsRequired);
            RuleFor(t => t.TableNo)
                .NotNull().WithMessage(Messages.TableNoIsRequired);
        }
    }
}
