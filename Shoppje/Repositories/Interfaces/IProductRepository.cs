﻿using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetProductsAsync();
        public Task<IEnumerable<ProductModel>>GetListProductOfSlug(int CategoryId);
        public Task<ProductModel> GetProductById(int id);
        Task AddProductAsync(ProductModel productModel);
        Task DeleteProductAsync(int id);
        Task EditProductAsync(ProductModel productModel);
    }
}
