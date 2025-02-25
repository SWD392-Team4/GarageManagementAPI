

using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;

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

        public async Task<Result<ProductImageDto>> CreateProductImageAsync(Guid productId, string imgId, string imgUrl)
        {
            var checkProduct = await GetAndCheckIfProductExist(productId, false);
            if (!checkProduct.IsSuccess)
                return Result<ProductImageDto>.Failure(checkProduct.StatusCode, checkProduct.Errors!);
            var productImgEntity = new ProductImage
            {
                ProductId = productId,
                ImageId = imgId,
                ImageLink = imgUrl,
                Status = ProductImageStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime()
            };

            await _repoManager.ProductImage.CreateProductImgAsync(productImgEntity);

            var productImgDtoToReturn = _mapper.Map<ProductImageDto>(productImgEntity);

            return productImgDtoToReturn.CreatedResult();
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

        public async Task<Result> UpdateProductImageAsync(Guid productImageId, ProductImageDtoForUpdate productImageDtoForUpdate, bool trackChanges)
        {
            var productImgResult = await GetAndCheckIfProductImageExist(productImageId, trackChanges);
            if (!productImgResult.IsSuccess)
                return Result<ProductImage>.Failure(productImgResult.StatusCode, productImgResult.Errors!);
            var productEntity = productImgResult.GetValue<ProductImage>();

            _mapper.Map(productImageDtoForUpdate, productEntity);

            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            _repoManager.ProductImage.UpdateProductImg(productEntity);
            await _repoManager.SaveAsync();

            return Result.Success(productImgResult.StatusCode);
        }

        private async Task<Result<Product>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundId(productId);

            return product.OkResult();
        }

        private async Task<Result<ProductImage>> GetAndCheckIfProductImageExist(Guid productImgId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.ProductImage.GetProductImgAsync(productImgId, trackChanges, include);
            if (product == null)
                return product.NotFoundId(productImgId);

            return product.OkResult();
        }
    }
}
