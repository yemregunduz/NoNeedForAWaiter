using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(od => od.ProductId)
                .NotNull().WithMessage(Messages.ProductIsRequired);
            RuleFor(od => od.Quantity)
                .NotNull().WithMessage(Messages.QuantityIsRequired)
                .GreaterThanOrEqualTo(1).WithMessage(Messages.QuantityIsNotValid);
            RuleFor(od => od.OrderId)
                .NotNull().WithMessage(Messages.OrderIdIsRequired);
        }
    }
}
