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
        public string Link { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
