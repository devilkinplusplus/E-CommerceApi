using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Create
{
    public class CreateBrandCommandRequest:IRequest<CreateBrandCommandResponse>
    {
        public string BrandName { get; set; }
        public IFormFile Logo { get; set; }
        public string WebRootPath{ get; set; }
    }
}
