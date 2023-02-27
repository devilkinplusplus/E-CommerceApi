using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.DTOs
{
    public class ProductDTO
    {
        public record CreateProductDTO(string title,string link,Guid brandId,Guid categoryId);
    }
}
