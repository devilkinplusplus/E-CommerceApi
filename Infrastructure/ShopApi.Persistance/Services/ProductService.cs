using Azure.Core;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.DTOs;
using ShopApi.Application.Repositories;
using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductWriteRepository _productWrite;
        private readonly IProductReadRepository _productRead;
        public ProductService(IProductWriteRepository productWrite, IProductReadRepository productRead)
        {
            _productWrite = productWrite;
            _productRead = productRead;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var data = await _productRead.GetByIdAsync(productId);
            data.IsDeleted = true;
            return _productWrite.Update(data);
        }

        public async Task<bool> UpdateProductAsync(Guid productId, ProductDTO.CreateProductDTO product)
        {
            var data = await _productRead.GetByIdAsync(productId);
            data.Title = product.title;
            data.Link = product.link;
            data.CategoryId = product.categoryId;
            data.BrandId = product.brandId;
            return _productWrite.Update(data);
        }
    }
}
