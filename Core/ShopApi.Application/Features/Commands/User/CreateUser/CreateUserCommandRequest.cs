using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.UserDTO;

namespace ShopApi.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public CreateUserDTO CreateUserModel { get; set; }
    }
}
