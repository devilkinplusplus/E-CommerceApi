using Autofac;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Abstractions.Services.Tokens;
using ShopApi.Application.Repositories;
using ShopApi.Persistance.Repositories;
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
            //services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            //repositories
            builder.RegisterType<CategoryReadRepository>().As<ICategoryReadRepository>();
            builder.RegisterType<CategoryWriteRepository>().As<ICategoryWriteRepository>();
            builder.RegisterType<BrandReadRepository>().As<IBrandReadRepository>();
            builder.RegisterType<BrandWriteRepository>().As<IBrandWriteRepository>();
            builder.RegisterType<ProductReadRepository>().As<IProductReadRepository>();
            builder.RegisterType<ProductWriteRepository>().As<IProductWriteRepository>();
        }
    }
}
