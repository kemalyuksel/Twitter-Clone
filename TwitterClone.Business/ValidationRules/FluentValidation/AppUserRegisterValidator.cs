using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Dto.DTOs.AppUserDtos;

namespace TwitterClone.Business.ValidationRules.FluentValidation
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Email).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.SurName).NotNull().WithMessage("Bu alan boş geçilemez");
        }

    }
}
