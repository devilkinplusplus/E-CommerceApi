using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entities.Concrete
{
    public class InvoiceFile:File
    {
        //sadece yoxlamaq üçün
        public decimal Price { get; set; }
    }
}
