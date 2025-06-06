﻿using Shoppje.Areas.admin.Models;
using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductById(int id);
        Task<bool> AddProductAsync(ProductCreateViewModel productCreateViewModel);
        Task DeleteProductAsync(int id);
        Task<bool> EditProductAsync(ProductEditViewModel productEditViewModel);
    }
}
