using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

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
        private async Task<Result<Product>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundId(productId);

            return product.OkResult();
        }
    }
}
