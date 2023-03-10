using Microsoft.AspNetCore.Identity;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Responses.User
{
    public class CreateUserResponse
    {
        public bool Succeeded { get; set; }
        public List<IdentityError> Errors { get; set; }
        public AppUser User { get; set; }
    }
}
