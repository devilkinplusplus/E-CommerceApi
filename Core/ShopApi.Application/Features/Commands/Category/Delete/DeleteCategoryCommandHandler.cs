using MediatR;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryWriteRepository _categoryWrite;
        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWrite, ICategoryService categoryService)
        {
            _categoryWrite = categoryWrite;
            _categoryService = categoryService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _categoryService.DeleteCategoryAsync(request.Id);
            if (res)
            {
                await _categoryWrite.SaveAsync();
                return new() { Succeeded = res, Message = "Deleted successfully" };
            }
            return new() { Succeeded = res, Message = "Something went wrong" };
        }
    }
}
