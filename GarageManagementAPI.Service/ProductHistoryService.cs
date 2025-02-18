using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GarageManagementAPI.Service
{
    public class ProductHistoryService : IProductHistoryService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public ProductHistoryService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }



        public async Task<Result<IEnumerable<ExpandoObject>>> GetHistoryProductByIdProductAsync(Guid productId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {

            var productsWithMetadata = await _repoManager.ProductHistory.GetProductHistoryByIdProductAsync(productId, productHistoryParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductHistoryDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductHistory.ShapeData(productsDto, productHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductHistoriesAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductHistory.GetProductHistoryAsync(productHistoryParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductHistoryDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductHistory.ShapeData(productsDto, productHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }
        private async Task UpdateDateProduct(Guid productId, DateTimeOffset updateAt, bool trackChanges)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges);

            var product = productResult.GetValue<Product>();

            var productEntity = _mapper.Map<Product>(product);   // Map the DTO to Product entity for update.

            productEntity.UpdatedAt = updateAt;

            _repoManager.Product.UpdateProductAsync(productEntity);

            await _repoManager.SaveAsync();
        }



       

        private async Task<bool> CheckIfProductByIdProduct(ProductHistoryDtoForCreation productHistoryDtoForCreation)
        {
            var productId = productHistoryDtoForCreation.ProductId;

            var product = await _repoManager.Product
                .FindByCondition(p => p.Id.Equals(productId), false)
                .AnyAsync();

            return product;
        }
        private async Task<Result<Product>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundId(productId);

            return product.OkResult();
        }
    }
}
