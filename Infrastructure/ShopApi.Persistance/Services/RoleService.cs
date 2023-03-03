using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Responses.Role;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CreateRoleResponse> CreateRoleAsync(string name)
        {
            if (name is null)
                return new() { Succeeded = false };
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole() { Name = name });
            if (result.Succeeded)
                return new() { Succeeded = true };
            return new() { Succeeded = false, Errors = (List<IdentityError>)result.Errors };
        }

        public async Task<bool> EditRoleAsync(string roleId, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            role.Name = roleName;
            var res = await _roleManager.UpdateAsync(role);
            return res.Succeeded;
        }

       
    }
}
