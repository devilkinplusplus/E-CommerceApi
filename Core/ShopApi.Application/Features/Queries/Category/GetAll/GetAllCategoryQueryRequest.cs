using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Queries.Category.GetAll
{
    public class GetAllCategoryQueryRequest:IRequest<GetAllCategoryQueryResponse>
    {
    }
}
