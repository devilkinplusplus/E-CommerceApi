using MediatR;
using ShopApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Role.EditRole
{
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommandRequest, EditRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public EditRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<EditRoleCommandResponse> Handle(EditRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _roleService.EditRoleAsync(request.Id, request.Name);
            if (res)
                return new() { Succeeded = res, Message = "Updated Successfully" };
            return new() { Succeeded = res, Message = "Something went wrong" };
        }
    }
}
