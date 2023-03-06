﻿using ShopApi.Application.Repositories;
using ShopApi.Domain.Entities.Concrete;
using ShopApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Repositories
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
