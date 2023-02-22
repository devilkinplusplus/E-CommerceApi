using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.DTOs
{
    public class AuthDTO
    {
        public record LoginDTO(string email,string password);
    }
}
