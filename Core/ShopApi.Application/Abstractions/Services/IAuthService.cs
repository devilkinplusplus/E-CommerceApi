using ShopApi.Application.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.AuthDTO;

namespace ShopApi.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginDTO model);
    }
}
