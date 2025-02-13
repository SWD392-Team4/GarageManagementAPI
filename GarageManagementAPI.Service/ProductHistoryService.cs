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

        public async Task<Result<ProductHistoryDto>> CreateProductHistoryAsync(ProductHistoryDtoForCreation productHistoryDtoForCreation)
        {
            var checkId = await CheckIfProductById(productHistoryDtoForCreation);
            var checkPrice = await CheckIfProductHistoryByIdAndPrice(productHistoryDtoForCreation);
            if (!checkId)
                return Result<ProductHistoryDto>.BadRequest([ProductErrors.GetProductNotFoundIdError(productHistoryDtoForCreation.ProductId)]);
            if (checkPrice)
                return Result<ProductHistoryDto>.BadRequest([ProductHistoryErrors.GetProductHistoryPriceAlreadyExistError(productHistoryDtoForCreation)]);

            // Gọi UpdateStatusProductHistory 
            await UpdateStatusProductHistory(productHistoryDtoForCreation.ProductId);

            var productEntity = _mapper.Map<ProductHistory>(productHistoryDtoForCreation);

            productEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productEntity.Status = ProductHistoryStatus.Active;

            await _repoManager.ProductHistory.CreateProductHisotoryAsync(productEntity);
            await _repoManager.SaveAsync();

            var productDtoToReturn = _mapper.Map<ProductHistoryDto>(productEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetHistoryProductByIdProductAsync(Guid productId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {

            var productsWithMetadata = await _repoManager.ProductHistory.GetProductByIdAsync(productId, productHistoryParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductHistoryDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductHistory.ShapeData(productsDto, productHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductHistoriesAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductHistory.GetProductsAsync(productHistoryParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductHistoryDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductHistory.ShapeData(productsDto, productHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        private async Task UpdateStatusProductHistory(Guid productId)
        {
            var pruductEntity = await GetHistoriesIsActiveAsync(productId);
            if (pruductEntity != null)
            {
                pruductEntity.Status = ProductHistoryStatus.Inactive;
                pruductEntity.UpdatedAt = DateTimeOffset.UtcNow;
                _repoManager.ProductHistory.UpdateProductHistory(pruductEntity);
                await _repoManager.SaveAsync();
            }
        }

        private async Task<bool> CheckIfProductHistoryByIdAndPrice(ProductHistoryDtoForCreation productHistoryDtoForCreation)
        {
            var productId = productHistoryDtoForCreation.ProductId;
            var productPrice = productHistoryDtoForCreation.ProductPrice;

            // Lấy bản ghi ProductHistory có UpdatedAt lớn nhất cho ProductId
            var latestProductHistory = await _repoManager.ProductHistory
                .FindByCondition(p => p.ProductId.Equals(productId), false)
                .OrderByDescending(p => p.UpdatedAt)
                .FirstOrDefaultAsync();

            if (latestProductHistory != null && latestProductHistory.ProductPrice.Equals(productPrice))
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CheckIfProductById(ProductHistoryDtoForCreation productHistoryDtoForCreation)
        {
            var productId = productHistoryDtoForCreation.ProductId;

            var product = await _repoManager.Product
                .FindByCondition(p => p.Id.Equals(productId), false)
                .AnyAsync();

            return product;
        }

        private async Task<ProductHistory?> GetHistoriesIsActiveAsync(Guid productId)
        {

            var productHistories = await _repoManager.ProductHistory
       .FindByCondition(p => p.Status == ProductHistoryStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
       .FirstOrDefaultAsync();

            return productHistories;
        }
    }
}
