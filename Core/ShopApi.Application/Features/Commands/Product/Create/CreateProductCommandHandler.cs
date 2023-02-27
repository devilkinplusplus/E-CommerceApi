using MediatR;
using Microsoft.AspNetCore.Http;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWrite;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateProductCommandHandler(IProductWriteRepository productWrite, IHttpContextAccessor contextAccessor)
        {
            _productWrite = productWrite;
            _contextAccessor = contextAccessor;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool res = await _productWrite.AddAsync(new()
            {
                Title = request.Title,
                Link = request.Link,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                UserId = userId
            });
            if (res)
            {
                await _productWrite.SaveAsync();
                return new() { Succeeded = true, Message = "Product added successfully" };
            }
            return new() { Succeeded = false, Message = "Something went wrong" };
        }
    }
}
