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

        public async Task<AssignRoleToUserResponse> AssignRoleToUser(string userId, string roleName)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);

            if (user is null || userId is null)
                return new() { Succeeded = false, Message = "Cannot found user" };

            if (!(await IsRoleNameExist(roleName)))
                return new() { Succeeded = false, Message = "Cannot found role" };

            IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
                return new() { Succeeded = true, Message = "Role assigned successfully!" };
            return new() { Succeeded = false, Message = "Something went wrong" };
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


        private async Task<bool> IsRoleNameExist(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            return role is not null ? true : false;
        }
    }
}
