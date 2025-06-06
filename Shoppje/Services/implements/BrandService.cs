﻿using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;
using System.Collections;

namespace Shoppje.Services.implements
{
    public class BrandService : IBrandService
    {
        private readonly IBrandReposiotry _brandReposiotry;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<BrandService> _logger;
        public BrandService(IBrandReposiotry brandReposiotry, IProductRepository productRepository, ILogger<BrandService> logger)
        {
            _brandReposiotry = brandReposiotry;
            _productRepository = productRepository;
            _logger = logger;
        }
        public Task<IEnumerable<ProductModel>> GetListProductOfSlug(string Slug)
        {
            var brand = _brandReposiotry.GetBrandBySlug(Slug);
            if (brand == null)
            {
                return Task.FromResult(Enumerable.Empty<ProductModel>());
            }
            return _productRepository.GetListProductOfSlug(brand.Result.Id);
        }

        public Task<BrandModel> GetBySlug(string Slug)
        {
            return _brandReposiotry.GetBrandBySlug(Slug);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _brandReposiotry.GetAll();
        }

        public Task<bool> AddBrandAsync(BrandCreateViewModel brandCreateViewModel)
        {
            var brand = new BrandModel
            {
                Name = brandCreateViewModel.Name,
                Slug = brandCreateViewModel.Name.ToLower().Replace(" ", "-"),
                Status = brandCreateViewModel.Status,
                Description = brandCreateViewModel.Description
            };
            return _brandReposiotry.AddBrandAsync(brand);
        }

        public async Task DeleteBrandAsync(int id)
        {
            try
            {
                await _brandReposiotry.DeleteBrandAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                _logger.LogError(ex, "Error deleting brand with ID {Id}", id);
            }
        }

        public Task<BrandModel> GetBrandById(int id)
        {
            return _brandReposiotry.GetBrandById(id);
        }

        public async Task<bool> EditCategoryAsync(BrandEditViewModel brandEditViewModel)
        {
            var brand = new BrandModel
            {
                Id = brandEditViewModel.Id,
                Name = brandEditViewModel.Name,
                Slug = brandEditViewModel.Name.ToLower().Replace(" ", "-"),
                Status = brandEditViewModel.Status,
                Description = brandEditViewModel.Description
            };
            try
            {
                await _brandReposiotry.EditBrandAsync(brand);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving brand with ID {Id} for editing", brand.Id);
                return false;
            }
        }
    }
}
