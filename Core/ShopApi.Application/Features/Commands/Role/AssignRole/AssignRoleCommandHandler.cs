using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Role.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, AssignRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        public AssignRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _roleService.AssignRoleToUser(request.UserId, request.RoleName);
            return new() { Succeeded = res.Succeeded, Message = res.Message };
        }
    }
}
