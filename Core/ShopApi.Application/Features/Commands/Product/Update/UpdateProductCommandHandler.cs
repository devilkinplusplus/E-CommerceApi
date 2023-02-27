using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly IProductWriteRepository _productWrite;
        public UpdateProductCommandHandler(IProductWriteRepository productWrite, IProductService productService)
        {
            _productWrite = productWrite;
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _productService.UpdateProductAsync(request.Id, request.NewProduct);

            if (res)
            {
                await _productWrite.SaveAsync();
                return new() { Succeeded = true, Message = "Updated successfully" };
            }
            return new() { Succeeded = false, Message = "Something went wrong" };
        
        }
    }
}
