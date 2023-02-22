using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Features.Commands.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _roleService.CreateRoleAsync(request.Name);
            return new() { Succeeded = res.Succeeded, Errors = res.Errors };
        }
    }
}
