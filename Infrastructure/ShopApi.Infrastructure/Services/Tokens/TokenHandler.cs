using ShopApi.Application.Abstractions.Services.Tokens;
using static ShopApi.Application.DTOs.AuthDTO;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ShopApi.Infrastructure.Services.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(AppUser user,string role)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                 {
                     new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim (ClaimTypes.Role, role),
                 }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Token:Issuer"],
                Audience = _configuration["Token:Auidence"]
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);

        }
    }
}
