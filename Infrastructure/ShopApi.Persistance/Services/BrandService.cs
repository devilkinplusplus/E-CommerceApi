using ShopApi.Application.Abstractions.Services;
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
        private readonly IBrandWriteRepository _brandWrite;
        public BrandService(IBrandWriteRepository brandWrite)
        {
            _brandWrite = brandWrite;
        }

        public Task<bool> CreateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
