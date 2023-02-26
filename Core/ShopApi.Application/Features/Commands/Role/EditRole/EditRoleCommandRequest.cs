using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Role.EditRole
{
    public class EditRoleCommandRequest:IRequest<EditRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
