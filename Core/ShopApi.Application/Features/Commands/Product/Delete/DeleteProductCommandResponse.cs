using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Delete
{
    public class DeleteProductCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
