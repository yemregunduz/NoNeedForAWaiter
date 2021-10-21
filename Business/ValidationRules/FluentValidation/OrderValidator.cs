using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator:AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.TableId)
                .NotNull().WithMessage(Messages.TableIdIsRequired);
            RuleFor(o => o.OrderDate)
                .NotNull().WithMessage(Messages.OrderDateIsRequired)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage(Messages.OrderDateIsNotValid);
        }
    }
}
