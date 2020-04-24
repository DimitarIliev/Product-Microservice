using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlixOne.BookStore.ProductService.Models;
using FlixOne.BookStore.ProductService.Persistance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlixOne.BookStore.ProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Get()
        {
            var productVm = _productRepository.GetAll().Select(x => new ProductViewModel
            {
                CategoryId = x.CategoryId,
                CategoryDescription = x.Category.Description,
                CategoryName = x.Category.Name,
                ProductDescription = x.Description,
                ProductId = x.Id,
                ProductImage = x.Image,
                ProductName = x.Name,
                ProductPrice = x.Price
            }).ToList();

            return new OkObjectResult(productVm);
        }
    }
}
