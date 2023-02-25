using ShopApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entities.Concrete
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
