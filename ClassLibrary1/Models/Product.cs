using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public List<ProductImages> ProductImages { get; set; } = new List<ProductImages>();
        public List<ProductSpeciality> ProductSpecialities { get; set; } = new List<ProductSpeciality>();
        public string Model { get; set; } = string.Empty;
        public int BrandID { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
