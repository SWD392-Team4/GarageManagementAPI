﻿using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.ProductCategory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;

namespace GarageManagementAPI.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public ProductCategoryService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result<ProductCategoryDto>> CreateProductCategoryAsync(ProductCategoryDtoForCreation productCategoryDtoForCreation)
        {
            var check = await GetAndCheckIfProductCategoryExistByName(productCategoryDtoForCreation.Category);
            if (check)
                return Result<ProductCategoryDto>.BadRequest([ProductCategoryErrors.GetProductCategoryNameAlreadyExistError(productCategoryDtoForCreation)]);

            var productCategoryEntity = _mapper.Map<ProductCategory>(productCategoryDtoForCreation);
            productCategoryEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productCategoryEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productCategoryEntity.Status = ProductCategoryStatus.Inactive;

            await _repoManager.ProductCategory.CreateProductCategoryAsync(productCategoryEntity);
            await _repoManager.SaveAsync();


            var productDtoToReturn = _mapper.Map<ProductCategoryDto>(productCategoryEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateProductCategory(Guid productCategoryId, ProductCategoryDtoForUpdate productCategoryDtoForUpdate, bool trackChanges)
        {
            var productCategoryResult = await GetAndCheckIfProductCategoryExistById(productCategoryId, trackChanges);
            if (!productCategoryResult.IsSuccess)
                return Result<ProductCategoryDtoForUpdate>.Failure(productCategoryResult.StatusCode, productCategoryResult.Errors!);
            var checkCategoryNameIsEXistResult = await GetAndCheckIfProductCategoryExistByName(productCategoryDtoForUpdate.Category, productCategoryId);
            if (checkCategoryNameIsEXistResult)
                return Result<ProductCategoryDto>.BadRequest([ProductCategoryErrors.GetProductCategoryNameUpdateAlreadyExistError(productCategoryDtoForUpdate)]);

            var productEntity = productCategoryResult.GetValue<ProductCategory>();

            _mapper.Map(productCategoryDtoForUpdate, productEntity);

            await _repoManager.SaveAsync();

            return Result.Success(productCategoryResult.StatusCode);
        }

        public async Task<Result<ExpandoObject>> GetProductCategoryByIdAsync(Guid productCategoryId, bool trackChanges, string? include = null)
        {
            var productCategoryResult = await GetAndCheckIfProductCategoryExistById(productCategoryId, trackChanges, include);

            if (!productCategoryResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productCategoryResult.Errors!);

            var productEntity = productCategoryResult.GetValue<ProductCategory>();

            var productCategoriesDto = _mapper.Map<ProductCategoryDto>(productEntity);

            var productShaped = _dataShaper.ProductCategory.ShapeData(productCategoriesDto, null);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<ProductCategoryDtoForUpdate>> GetProductCategoryForPartiallyUpdate(Guid productCategoryId, bool trackChanges)
        {
            var productCategoryResult = await GetAndCheckIfProductCategoryExistById(productCategoryId, trackChanges);
            if (!productCategoryResult.IsSuccess)
                return Result<ProductCategoryDtoForUpdate>.Failure(productCategoryResult.StatusCode, productCategoryResult.Errors!);

            var productEntity = productCategoryResult.GetValue<Product>();

            var productDtoForUpdate = _mapper.Map<ProductCategoryDtoForUpdate>(productEntity);

            return Result<ProductCategoryDtoForUpdate>.Ok(productDtoForUpdate);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null)
        {
            var productCategoriesWithMetadata = await _repoManager.ProductCategory.GetProductCategoriesAsync(productCategoryParameters, trackChanges, include);

            var productCategoriesDto = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategoriesWithMetadata);

            var productCategoriesShaped = _dataShaper.ProductCategory.ShapeData(productCategoriesDto, productCategoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productCategoriesShaped, productCategoriesWithMetadata.MetaData);
        }

        private async Task<bool> GetAndCheckIfProductCategoryExistByName(string name, Guid? id = null)
        {
            var productcategory = await _repoManager.ProductCategory.GetProductByIdAndNameAsync(name, id, false);
            if (productcategory == null)
                return false;

            return true;
        }

        private async Task<Result<ProductCategory>> GetAndCheckIfProductCategoryExistById(Guid productCategoryId, bool trackChanges, string? include = null)
        {
            var productcategory = await _repoManager.ProductCategory.GetProductCategoryByIdAsync(productCategoryId, trackChanges, include);
            if (productcategory == null)
                return productcategory.NotFound(productCategoryId);

            return productcategory.OkResult();
        }
    }
}
