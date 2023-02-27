using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandService _brandService;
        private readonly IBrandWriteRepository _brandWrite;
        public UpdateBrandCommandHandler(IBrandService brandService, IBrandWriteRepository brandWrite)
        {
            _brandService = brandService;
            _brandWrite = brandWrite;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.NewName == null && request.NewLogo == null)
                return new() { Succeeded = true,Message = "Nothing changes" };

            var res = await _brandService.UpdateBrandAsync(request.Id, request.NewName, request.NewLogo, request.WebRootPath);
            if(res)
            {
                await _brandWrite.SaveAsync();
                return new() { Succeeded = res, Message = "Updated successfully" };
            }
            return new() { Succeeded = res, Message = "Something went wrong" };
        }
    }
}
