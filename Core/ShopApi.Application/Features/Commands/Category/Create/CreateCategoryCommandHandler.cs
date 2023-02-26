using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryService _categoryService;
        public CreateCategoryCommandHandler(ICategoryService categoryService, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryService = categoryService;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _categoryService.CreateCategoryAsync(request.Name);
            if (res)
            {
                await _categoryWriteRepository.SaveAsync();
                return new() { Succeeded = res ,Message ="Created successfully"};
            }
            return new() { Succeeded = false ,Message = "Something went wrong"};
        }
    }
}
