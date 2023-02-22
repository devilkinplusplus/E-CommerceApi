using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Abstractions.Services.Tokens;
using ShopApi.Application.Responses.Auth;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.AuthDTO;

namespace ShopApi.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AuthService(ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.email);

            if (user is null)
                return new() { Succeeded = false, Message = "Email is not correct" };

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.password, true, true);

            if (result.Succeeded)
            {
                string token =  _tokenHandler.CreateToken(user, "User");
                return new() { Succeeded = true, Message = token };
            }

            return new() { Succeeded = false, Message = "Password is incorrcet" };
        }
    }
}
