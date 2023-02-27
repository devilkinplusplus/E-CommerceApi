using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandService _brandService;
        private readonly IBrandWriteRepository _brandWrite;
        public CreateBrandCommandHandler(IBrandService brandService, IBrandWriteRepository brandWrite)
        {
            _brandService = brandService;
            _brandWrite = brandWrite;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _brandService.CreateBrandAsync(request.BrandName, request.Logo, request.WebRootPath);
            if (res)
            {
                await _brandWrite.SaveAsync();
                return new() { Succeeded = true, Message = "Brand added successfully" };
            }
            return new() { Succeeded = false, Message = "Something went wrong" };

        }
    }
}
