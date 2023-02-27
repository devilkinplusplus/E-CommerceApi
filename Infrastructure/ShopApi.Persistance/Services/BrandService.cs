using Microsoft.AspNetCore.Http;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Helpers.FileHelper;
using ShopApi.Application.Repositories;
using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandReadRepository _brandRead;
        private readonly IBrandWriteRepository _brandWrite;
        public BrandService(IBrandWriteRepository brandWrite, IBrandReadRepository brandRead)
        {
            _brandWrite = brandWrite;
            _brandRead = brandRead;
        }

        public async Task<bool> CreateBrandAsync(string brandName, IFormFile logo, string webRootPath)
        {
            var res = logo.UploadPicture(webRootPath);
            return await _brandWrite.AddAsync(new() { Name = brandName, Logo = res });
        }

        public async Task<bool> DeleteBrandAsync(Guid brandId)
        {
            var data = await _brandRead.GetByIdAsync(brandId);
            data.IsDeleted = true;
            return _brandWrite.Update(data);
        }

        public async Task<bool> UpdateBrandAsync(Guid brandId, string newBrandName, IFormFile newLogo, string webRootPath)
        {
            var data = await _brandRead.GetByIdAsync(brandId);
            string newPath = string.Empty;
            if (newLogo != null)
            {
                newPath = newLogo.UploadPicture(webRootPath);
                data.Logo = newPath;
            }
            if(newBrandName != null)
                data.Name = newBrandName;
    
            return _brandWrite.Update(data);
        }
    }
}
