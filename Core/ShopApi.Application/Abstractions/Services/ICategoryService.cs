using ShopApi.Application.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(string name);
        Task<bool> EditCategoryAsync(Guid id,string name);
        Task<bool> DeleteCategoryAsync(Guid id);
    }
}
