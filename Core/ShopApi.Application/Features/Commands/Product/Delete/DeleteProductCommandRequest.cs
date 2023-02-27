using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Delete
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
