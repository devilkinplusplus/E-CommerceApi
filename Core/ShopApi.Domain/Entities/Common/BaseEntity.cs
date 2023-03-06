using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        //virtual açar sözü ilə override edilə bilir hala saldıq,çünki alt siniflərin hamısında bu propertini istifadə etməyə bilərik, o zaman override edib [NotMapped] demek kifayetdir
        public DateTime Date { get; set; }

    }
}
