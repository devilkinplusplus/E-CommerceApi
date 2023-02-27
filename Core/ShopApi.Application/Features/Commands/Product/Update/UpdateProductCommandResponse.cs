using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
