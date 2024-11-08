using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorypattern.core.IDatabaseRepository;
using Repositorypattern.core.Models;
using Repositorypattern.core.UnitofWork;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOFWork unitOFWork;

        public ProductController(IUnitOFWork unitOFWork)
        {
            this.unitOFWork = unitOFWork;
        }


        [HttpGet("Products")]
        public IActionResult getall()
        {
            var products = unitOFWork.Products.GetAllWith(new string[] {"Brand", "ProductImages" }).ToList();
            List<ProductWithAllInformation> productsResponse = new List<ProductWithAllInformation>();
            foreach (var product in products)
            {

                productsResponse.Add(new ProductWithAllInformation()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Description = product.Description,
                    Rating = product.Rating,
                    Model = product.Model,
                    BrandName= product.Brand.Name,
                ProductImageUrl = product.ProductImages.Select(e=>e.ImageUrl).ToList(),
                });
            }
        
           
            return Ok(productsResponse);

        }




        [HttpGet("/{special}")]
        public IActionResult special(string special)
        {
            var products = unitOFWork.Products.GetSpeciality(special);

                List<ProductWithAllInformation> productsResponse = new List<ProductWithAllInformation>();
            foreach (var product in products)
            {

                productsResponse.Add(new ProductWithAllInformation()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Description = product.Description,
                    Rating = product.Rating,
                    Model = product.Model,
                    BrandName = product.Brand.Name,
                    ProductImageUrl = product.ProductImages.Select(e => e.ImageUrl).ToList(),
                });
            }

            return Ok(productsResponse);

        }


        [HttpPost("filter")]
        public IActionResult filter(FilterModel filterModel)
        {
            
            var products = unitOFWork.Products.GetFilter(filterModel.BrandName,filterModel.ProductPriceMax ,
                filterModel.ProductPriceMin
                , filterModel.Rating);

            List<ProductWithAllInformation> productsResponse = new List<ProductWithAllInformation>();
            foreach (var product in products)
            {

                productsResponse.Add(new ProductWithAllInformation()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Description = product.Description,
                    Rating = product.Rating,
                    Model = product.Model,
                    BrandName = product.Brand.Name,
                    ProductImageUrl = product.ProductImages.Select(e => e.ImageUrl).ToList(),
                });
            }

            return Ok(productsResponse);

        }





    }
}
