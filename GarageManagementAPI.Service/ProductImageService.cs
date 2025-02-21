

using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public ProductImageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }


        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductImageByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductImage.GetProductImgByIdProductAsync(productId, productImageParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductImageDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductImage.ShapeData(productsDto, productImageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductImagesAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductImage.GetProductImgsAsync(productImageParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductImageDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.ProductImage.ShapeData(productsDto, productImageParameters.Fields);

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
