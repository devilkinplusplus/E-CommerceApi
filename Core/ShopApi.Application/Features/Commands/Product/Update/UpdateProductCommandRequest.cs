using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.ProductDTO;

namespace ShopApi.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public CreateProductDTO NewProduct { get; set; }
    }
}
