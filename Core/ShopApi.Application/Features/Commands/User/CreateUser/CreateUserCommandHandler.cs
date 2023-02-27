using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public CreateUserCommandHandler(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateUserAsync(request.CreateUserModel);
            if (response.Succeeded)
            {
                await _roleService.AssignRoleToUser(response.User.Id, "User");   
                return new() { Succeeded = true,Message = "You have registered successfully" };
            }
            return new() { Succeeded = false, Errors = response.Errors };
        }
    }
}
