using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Entities.Common;
using ShopApi.Domain.Entities.Concrete;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Context
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in data)
            {
                if(item.State == EntityState.Added || item.State == EntityState.Modified)
                    item.Entity.Date = DateTime.UtcNow;
            }
            
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
