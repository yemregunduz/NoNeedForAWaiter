using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductImageValidator:AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(p => p.ProductId)
                .NotNull().WithMessage(Messages.ProductIsRequired)
                .GreaterThan(0).WithMessage(Messages.ProductIsRequired);
            RuleFor(p => p.ProductImagePath)
                .NotEmpty().WithMessage(Messages.ProductImagePathIsRequired);
        }
    }
}
