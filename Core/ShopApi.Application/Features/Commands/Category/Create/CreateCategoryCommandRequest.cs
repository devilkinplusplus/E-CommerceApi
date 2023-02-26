using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
