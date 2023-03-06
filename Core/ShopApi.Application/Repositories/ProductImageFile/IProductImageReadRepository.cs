using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Repositories
{
    public interface IProductImageReadRepository:IReadRepository<ProductImageFile>
    {
    }
}
