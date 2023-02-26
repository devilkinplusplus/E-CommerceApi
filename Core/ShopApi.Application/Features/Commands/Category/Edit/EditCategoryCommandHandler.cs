using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Edit
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommandRequest, EditCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        public EditCategoryCommandHandler(ICategoryService categoryService, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryService = categoryService;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<EditCategoryCommandResponse> Handle(EditCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _categoryService.EditCategoryAsync(request.Id, request.Name);
            if(res)
            {
                await _categoryWriteRepository.SaveAsync();
                return new() { Succeeded = res, Message = "Updated successfully" };
            }
            return new() { Succeeded = res, Message = "Something went wrong" };
        }
    }
}
