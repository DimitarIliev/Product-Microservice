using FlixOne.BookStore.ProductService.Controllers;
using FlixOne.BookStore.ProductService.Helpers.Extensions;
using FlixOne.BookStore.ProductService.Models;
using FlixOne.BookStore.ProductService.Persistance;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FlixOne.BookStore.ProductService.UnitTests.Services
{
    public class ProductTests
    {
        private IEnumerable<ProductViewModel> GetProducts()
        {
            var productVm = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryDescription = "Category Description",
                    CategoryName = "Category Name",
                    ProductDescription = "Product Description",
                    ProductId = Guid.NewGuid(),
                    ProductImage = "Product Image",
                    ProductName = "Product Name",
                    ProductPrice = 112M
                },
                new ProductViewModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryDescription = "Category Description 1",
                    CategoryName = "Category Name 1",
                    ProductDescription = "Product Description 1",
                    ProductId = Guid.NewGuid(),
                    ProductImage = "Product Image 1",
                    ProductName = "Product Name 1",
                    ProductPrice = 12M
                }
            };

            return productVm;
        }

        [Fact]
        public void Get_Returns_ActionResults()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll().ToViewModel()).Returns(GetProducts());
            var controller = new ProductController(mockRepo.Object);
            //Act
            var result = controller.Get();
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Value);
            Assert.Equal(2, model.Count());
        }
    }
}
