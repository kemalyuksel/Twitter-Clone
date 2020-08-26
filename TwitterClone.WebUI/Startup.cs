using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterClone.Business.Containers.MicrosoftIoC;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.CustomCollectionExtensions;

namespace TwitterClone.WebUI
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDependencies();
            services.AddCustomIdentity();
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomValidator();
            services.AddControllersWithViews().AddFluentValidation();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                     );

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                
            });
        }
    }
}
