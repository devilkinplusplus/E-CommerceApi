using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Role.AssignRole
{
    public class AssignRoleCommandRequest:IRequest<AssignRoleCommandResponse>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
