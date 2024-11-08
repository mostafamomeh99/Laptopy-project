﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.core.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
