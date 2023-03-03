using Autofac;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Application.Abstractions.Services;
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
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();

            //repositories
            builder.RegisterType<ProductReadRepository>().As<IProductReadRepository>();
            builder.RegisterType<ProductWriteRepository>().As<IProductWriteRepository>();
            builder.RegisterType<CustomerReadRepository>().As<ICustomerReadRepository>();
            builder.RegisterType<CustomerWriteRepository>().As<ICustomerWriteRepository>();
            builder.RegisterType<OrderReadRepository>().As<IOrderReadRepository>();
            builder.RegisterType<OrderWriteRepository>().As<IOrderWriteRepository>();
        }
    }
}
