using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Business.ValidationRules.FluentValidation;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.WebUI.CustomCollectionExtensions
{
    public static class CollectionExtension
    {

        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<TwitterContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "TwitterCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });

        }

        public static void AddCustomValidator(this IServiceCollection services)
        {

            services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserSignInValidator>();

        }

    }
}
