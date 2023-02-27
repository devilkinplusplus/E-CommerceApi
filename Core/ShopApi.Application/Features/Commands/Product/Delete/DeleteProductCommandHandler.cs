using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWrite;
        private readonly IProductService _productService;
        public DeleteProductCommandHandler(IProductWriteRepository productWrite, IProductService productService)
        {
            _productWrite = productWrite;
            _productService = productService;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool res = await _productService.DeleteProductAsync(request.Id);
            if(res)
            {
                await _productWrite.SaveAsync();
                return new() { Succeeded = res, Message = "Deleted successfully" };
            }
            return new() { Succeeded = res, Message = "Something went wrong" };
        }
    }
}
