using Microsoft.EntityFrameworkCore;
using Repositorypattern.core.IDatabaseRepository;
using Repositorypattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ef.Repositories
{
    public class ProductRepository : DatabaseRepository<Product>
        , IProductRepository
    { 
        private readonly List<Product> products;
        private readonly IQueryable<ProductSpeciality> productspecial;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this.products = context.Products.Include(e=>e.ProductSpecialities).Include(e=>e.ProductImages)
                .Include(e=>e.Brand)
                .ToList();
            this.productspecial = context.ProductSpeciality;
        }

        public IEnumerable<Product> GetSpeciality(string special)

        {
            List<Product> response = new List<Product>();

            foreach (var item in productspecial)
            {
                if (  special.ToLower() == item.Caretria.ToString().ToLower() )
                {
                    var responseProduct = products.Find(e => e.Id == item.ProductId);
                    if (responseProduct != null) 
                    {

                        response.Add(responseProduct);
                    }
                }

            }

            return response;  }




        public IEnumerable<Product> GetFilter(string brand, decimal priceMax, decimal priceMin, string rate)
        {
            var response = new List<Product>();

            foreach (var product in products)
            {
                if (priceMin < product.Price&& product.Price < priceMax)
                {
                    response.Add(product);
                }
                else if (product.Brand.Name.ToLower()== brand.ToLower())
                { response.Add(product); }

                else if (product.Rating== rate)
                {
                    response.Add(product);
                }
            }


            return response;

        }





    }
}
