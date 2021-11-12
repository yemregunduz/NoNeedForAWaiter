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
            //RuleFor(u => u.BirthOfDate)
            //    .NotEmpty().WithMessage(Messages.BirthOfDateIsRequired);
            //RuleFor(u => u.DateOfRecruitment)
            //    .NotEmpty().WithMessage(Messages.DateOfRecruitmentIsRequired);
            //RuleFor(u => u.TcNo)
            //    .NotEmpty().WithMessage(Messages.TcNoIsRequired)
            //    .Must(CheckIfTcNoIsValid).WithMessage(Messages.TcNoIsNotValid);

        }
        private bool CheckIfTcNoIsValid(string TCNO)
        {
            if (TCNO.Length == 11)
            {
                int N1 = Convert.ToInt32(TCNO[0].ToString());
                int N2 = Convert.ToInt32(TCNO[1].ToString());
                int N3 = Convert.ToInt32(TCNO[2].ToString());
                int N4 = Convert.ToInt32(TCNO[3].ToString());
                int N5 = Convert.ToInt32(TCNO[4].ToString());
                int N6 = Convert.ToInt32(TCNO[5].ToString());
                int N7 = Convert.ToInt32(TCNO[6].ToString());
                int N8 = Convert.ToInt32(TCNO[7].ToString());
                int N9 = Convert.ToInt32(TCNO[8].ToString());
                int N10 = Convert.ToInt32(TCNO[9].ToString());
                int N11 = Convert.ToInt32(TCNO[10].ToString());
                if (((((N1 + N3 + N5 + N7 + N9) * 7) - (N2 + N4 + N6 + N8)) % 10) != N10)
                {
                    return false;
                }

                return (N1 + N2 + N3 + N4 + N5 + N6 + N7 + N8 + N9 + N10) % 10 == N11;
            }
            else
            {
                return false;
            }
        }

    }
}
