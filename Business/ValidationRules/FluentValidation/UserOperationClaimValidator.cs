using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator:AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(u => u.UserId)
                .NotNull().WithMessage(Messages.UserIdIsRequired);
            RuleFor(u => u.OperationClaimId)
                .NotEmpty().WithMessage(Messages.OperationClaimIdIsRequired);
        }
    }
}
