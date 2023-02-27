using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.ProductDTO;

namespace ShopApi.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<bool> UpdateProductAsync(Guid productId,CreateProductDTO product);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
