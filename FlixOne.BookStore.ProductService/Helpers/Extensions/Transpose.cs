﻿using FlixOne.BookStore.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlixOne.BookStore.ProductService.Helpers.Extensions
{
    public static class Transpose
    {
        public static ProductViewModel ToViewModel(this Product product)
            => new ProductViewModel
            {
                CategoryId = product.CategoryId,
                CategoryDescription = product.Category.Description,
                CategoryName = product.Category.Name,
                ProductDescription = product.Description,
                ProductId = product.Id,
                ProductImage = product.Image,
                ProductName = product.Name,
                ProductPrice = product.Price
            };

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Product> products)
            => products.Select(ToViewModel).ToList();
    }
}
