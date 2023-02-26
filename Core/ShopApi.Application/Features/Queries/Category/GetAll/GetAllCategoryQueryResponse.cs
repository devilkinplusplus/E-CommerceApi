using ShopApi.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Queries.Category.GetAll
{
    public class GetAllCategoryQueryResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<Domain.Entities.Concrete.Category> Categories { get; set; }
    }
}
