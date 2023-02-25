using ShopApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
    
    }
}
