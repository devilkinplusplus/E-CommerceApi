using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.RequestParameters
{
    public record Pagination //Class olması şert deyil record veya struct da ola biler
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
