using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Queries.Category.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryRead;
        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryRead)
        {
            _categoryRead = categoryRead;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRead.GetAll(x => x.IsDeleted == false).ToListAsync();
            if (categories.Count == 0)
                return new() { Succeeded = false ,Message = "No categories found"};
            return new() { Succeeded = true,Categories = categories };
        }
    }
}
