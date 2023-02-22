using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApi.Persistance.Context;
using ShopApi.Domain.Entities.Identity;
using Microsoft.IdentityModel.Protocols;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Persistance.Services;

namespace ShopApi.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.ConnectionString);
            });

            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddSignInManager<SignInManager<AppUser>>();


            services.AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application", options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
        }
    }
}
