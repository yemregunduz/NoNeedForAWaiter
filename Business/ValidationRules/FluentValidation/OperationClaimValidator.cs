using Core.Entities.Concrete;
using FluentValidation;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator:AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(o => o.Name)
                .Must(CheckIfOperationClaimContainsUpperCase).WithMessage(Messages.OperationClaimNameCannotContainUpperCase);
        }

        private bool CheckIfOperationClaimContainsUpperCase(string operationClaimName)
        {
            if (operationClaimName.Any(char.IsUpper) == true)
            {
                return false;
            }
            return true;
        }
    }
}
