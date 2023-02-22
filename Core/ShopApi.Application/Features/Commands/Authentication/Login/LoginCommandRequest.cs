using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.AuthDTO;

namespace ShopApi.Application.Features.Commands.Authentication.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public LoginDTO LoginDTO { get; set; }
    }
}
