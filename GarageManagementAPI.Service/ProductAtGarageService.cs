using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Service
{
    public class ProductAtGarageService : IProductAtGarageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShapper;

        public ProductAtGarageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShapper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShapper = dataShapper;
        }

        public async Task<Result<ExpandoObject>> GetProductAtGarage(Guid productAtGarageid, bool trackChanges, string? include = null)
        {
            var productAtWarehouse = await this.GetAndCheckProductAtGarage(productAtGarageid, trackChanges, include);
            if(!productAtWarehouse.IsSuccess) return Result<ExpandoObject>.Failure(productAtWarehouse);
            var productEntity = productAtWarehouse.GetValue<ProductAtGarage>();
            var productAtHouseDto = _mapper.Map<ProductAtGarageDto>(productEntity);
            var productAtHouseShapper = _dataShapper.ProductAtGarage.ShapeData(productAtHouseDto, null);
            return Result<ExpandoObject>.Ok(productAtHouseShapper);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductAtWarehouses(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductAtGarage.GetProductAtGarages(productAtGarageParameters, trackChanges, include);

            var productIds = productsWithMetadata.Select(p => p.Id).ToList();

            var productAtHouseDto = _mapper.Map<IEnumerable<ProductAtGarageDto>>(productsWithMetadata);


            var productQuantities = await _repoManager.ProductAtGarage.GetTotalQuantityByProductIdAsync();

            foreach (var productDto in productAtHouseDto)
            {
                productDto.Quantity = productQuantities.ContainsKey(productDto.ProductId) ? productQuantities[productDto.ProductId] : 0;
            }

            var productAtHouseShapper = _dataShapper.ProductAtGarage.ShapeData(productAtHouseDto, productAtGarageParameters.Fields);
            return Result<IEnumerable<ExpandoObject>>.Ok(productAtHouseShapper, productsWithMetadata.MetaData);
        }

        private async Task<Result<ProductAtGarage>> GetAndCheckProductAtGarage(Guid productAtGarageId, bool trackChanges, string? include = null)
        {
            var productAtGarage = await _repoManager.ProductAtGarage.GetProductAtGarage(productAtGarageId, trackChanges, include);
            if (productAtGarage == null) return productAtGarage.NotFound(productAtGarageId);
            return productAtGarage.OkResukt();
        }
    }
}
