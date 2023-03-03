using ShopApi.Application.Responses.Role;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<CreateRoleResponse> CreateRoleAsync(string name);
        Task<bool> EditRoleAsync(string roleId,string roleName);
    }
}
