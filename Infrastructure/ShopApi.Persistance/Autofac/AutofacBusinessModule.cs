using Autofac;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Abstractions.Services.Tokens;
using ShopApi.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}
