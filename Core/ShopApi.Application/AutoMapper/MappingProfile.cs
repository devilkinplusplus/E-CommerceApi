using AutoMapper;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.AuthDTO;
using static ShopApi.Application.DTOs.UserDTO;

namespace ShopApi.Application.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, AppUser>().ReverseMap();
            CreateMap<LoginDTO,AppUser>().ReverseMap();
        }
    }
}
