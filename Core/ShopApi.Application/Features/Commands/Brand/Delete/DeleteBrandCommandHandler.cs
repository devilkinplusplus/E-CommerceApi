using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Delete
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IBrandService _brandService;
        private readonly IBrandWriteRepository _brandWrite;
        public DeleteBrandCommandHandler(IBrandService brandService, IBrandWriteRepository brandWrite)
        {
            _brandService = brandService;
            _brandWrite = brandWrite;
        }

        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            bool res = await _brandService.DeleteBrandAsync(request.Id);
            if (res)
            {
                await _brandWrite.SaveAsync();
                return new() { Succeeded = true, Message = "Deleted successfully" };
            }
            return new() { Succeeded = false, Message = "Something went wrong" };
        }
    }
}