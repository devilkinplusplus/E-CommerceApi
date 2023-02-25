using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Logo).IsRequired();
        }
    }
}
