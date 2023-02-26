using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Category.Edit
{
    public class EditCategoryCommandRequest:IRequest<EditCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
