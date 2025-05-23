﻿using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
