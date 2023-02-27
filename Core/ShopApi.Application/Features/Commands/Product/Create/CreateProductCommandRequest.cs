using MediatR;
using ShopApi.Domain.Entities.Concrete;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string UserId { get; set; }
    }
}
