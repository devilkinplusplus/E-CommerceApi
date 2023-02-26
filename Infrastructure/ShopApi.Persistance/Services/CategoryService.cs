using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using ShopApi.Application.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryWriteRepository _categoryWrite;
        private readonly ICategoryReadRepository _categoryRead;
        public CategoryService(ICategoryWriteRepository categoryWrite, ICategoryReadRepository categoryRead)
        {
            _categoryWrite = categoryWrite;
            _categoryRead = categoryRead;
        }

        public async Task<bool> CreateCategoryAsync(string name)
        {
            var res = await _categoryWrite.AddAsync(new() { Name = name });
            return res;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var data = await _categoryRead.GetByIdAsync(id);
            data.IsDeleted = true;
            return _categoryWrite.Update(data);
        }

        public async Task<bool> EditCategoryAsync(Guid id,string name)
        {
            var currentData = await _categoryRead.GetByIdAsync(id);
            currentData.Name = name;
            return _categoryWrite.Update(currentData);
        }
    }
}
