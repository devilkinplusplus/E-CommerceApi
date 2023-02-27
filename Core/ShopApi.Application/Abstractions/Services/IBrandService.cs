using Microsoft.AspNetCore.Http;
using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Abstractions.Services
{
    public interface IBrandService
    {
        Task<bool> CreateBrandAsync(string brandName,IFormFile logo,string webRootPath);
        Task<bool> UpdateBrandAsync(Guid brandId,string newBrandName,IFormFile newLogo,string webRootPath);
        Task<bool> DeleteBrandAsync(Guid brandId);
    }
}
