﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Repositories
{
    public interface IFileWriteRepository:IWriteRepository<Domain.Entities.Concrete.File>
    {
    }
}