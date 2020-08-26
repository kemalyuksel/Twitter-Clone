using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Dto.DTOs.AppUserDtos;

namespace TwitterClone.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserLoginDto>
    {

        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Bu alan boş geçilemez");

        }

    }
}
