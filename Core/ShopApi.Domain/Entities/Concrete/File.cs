using ShopApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Domain.Entities.Concrete
{
    //Table per hierarchy 
    public class File:BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Storage { get; set; }

        //BaseEntity-den gelen bu properti bu entity-de migrate edilmesin <3
        [NotMapped]
        public override bool IsDeleted { get => base.IsDeleted; set => base.IsDeleted = value; }
    }
}
