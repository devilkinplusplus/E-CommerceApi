using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.AuthDTO;

namespace ShopApi.Application.Abstractions.Services.Tokens
{
    public interface ITokenHandler
    {
        string CreateToken(AppUser user, string role);
    }
}
