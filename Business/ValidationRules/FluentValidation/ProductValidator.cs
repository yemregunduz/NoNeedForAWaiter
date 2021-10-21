using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotNull().WithMessage(Messages.CategoryIdIsRequired);
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage(Messages.ProductNameIsRequired)
                .Length(2, 100).WithMessage(Messages.ProductNameIsNotValid);
            RuleFor(p => p.UnitPrice)
                .NotNull().WithMessage(Messages.UnitPriceIsRequired)
                .GreaterThan(0).WithMessage(Messages.UnitPriceIsNotValid);
            RuleFor(p => p.RestaurantId)
                .NotNull().WithMessage(Messages.RestaurantIdIsRequired);
            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage(Messages.StockIsNotValid);
            RuleFor(p => p.ProductDescription)
                .MaximumLength(250).WithMessage(Messages.ProductDescriptionIsNotValid);
        }
    }
}
