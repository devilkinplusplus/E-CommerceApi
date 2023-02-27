using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Delete
{
    public class DeleteBrandCommandRequest:IRequest<DeleteBrandCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
