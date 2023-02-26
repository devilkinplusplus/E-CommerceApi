using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message{ get; set; }
    }
}
