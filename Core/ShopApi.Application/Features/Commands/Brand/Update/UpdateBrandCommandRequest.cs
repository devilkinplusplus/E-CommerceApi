using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Update
{
    public class UpdateBrandCommandRequest:IRequest<UpdateBrandCommandResponse>
    {
        public Guid Id { get; set; }
        public string? NewName{ get; set; }
        public IFormFile? NewLogo{ get; set; }
        public string WebRootPath { get; set; }
    }
}
