using ShopApi.Domain.Entities.Common;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}
