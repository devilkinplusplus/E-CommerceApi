﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.Brand.Delete
{
    public class DeleteBrandCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
