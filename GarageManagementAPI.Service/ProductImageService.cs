

using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductImg;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.Extension;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<ProductImageDto>> CreateProductImageAsync(ProductImageDtoForCreation productImageDtoForCreation)
        {
            var checkId = await CheckIfProductByIdProduct(productImageDtoForCreation);
            var checkLink = await CheckIfProductImgByIdAndLink(productImageDtoForCreation);
            if (!checkId)
                return Result<ProductImageDto>.BadRequest([ProductErrors.GetProductNotFoundIdError(productImageDtoForCreation.ProductId)]);
            if (checkLink)
                return Result<ProductImageDto>.BadRequest([ProductImgErrors.GetProductImageLinkAlreadyExistError(productImageDtoForCreation)]);

            var date = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            // Gọi UpdateStatusImage 
            await UpdateStatusProductImage(productImageDtoForCreation.ProductId);
            await UpdateDateProduct(productImageDtoForCreation.ProductId, date, false);

            var productImgEntity = _mapper.Map<ProductImage>(productImageDtoForCreation);

            productImgEntity.CreatedAt = date;
            productImgEntity.UpdatedAt = date;
            productImgEntity.Status = ProductImageStatus.Active;

            await _repoManager.ProductImage.CreateProductImgAsync(productImgEntity);
            await _repoManager.SaveAsync();

            var productDtoToReturn = _mapper.Map<ProductImageDto>(productImgEntity);

            return productDtoToReturn.CreatedResult();
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

        private async Task UpdateDateProduct(Guid productId, DateTimeOffset updateAt, bool trackChanges)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges);

            var productDtoWithPrice = productResult.GetValue<ProductDtoWithPrice>();
            Console.WriteLine(productDtoWithPrice);

            var productEntity = _mapper.Map<Product>(productDtoWithPrice);   // Map the DTO to Product entity for update.

            _mapper.Map(productDtoWithPrice, productEntity); // Apply the updates from the provided DTO.

            productEntity.UpdatedAt = updateAt;

            _repoManager.Product.UpdateProductAsync(productEntity);

            await _repoManager.SaveAsync();
        }

        private async Task UpdateStatusProductImage(Guid productId)
        {
            var productEntity = await GetImagesIsActiveAsync(productId);
            if (productEntity != null)
            {
                productEntity.Status = ProductImageStatus.Inactive;
                productEntity.UpdatedAt = DateTimeOffset.UtcNow;
                _repoManager.ProductImage.UpdateProductImg(productEntity);
                await _repoManager.SaveAsync();
            }
        }

        private async Task<bool> CheckIfProductByIdProduct(ProductImageDtoForCreation ProductImageDtoForCreation)
        {
            var productId = ProductImageDtoForCreation.ProductId;

            var product = await _repoManager.Product
                .FindByCondition(p => p.Id.Equals(productId), false)
                .AnyAsync();

            return product;
        }

        private async Task<bool> CheckIfProductImgByIdAndLink(ProductImageDtoForCreation ProductImageDtoForCreation)
        {
            var productId = ProductImageDtoForCreation.ProductId;
            var productLink = ProductImageDtoForCreation.Link;

            // Lấy bản ghi Product Img có UpdatedAt lớn nhất cho ProductId
            var latestProductImg = await _repoManager.ProductImage
                .FindByCondition(p => p.ProductId.Equals(productId), false)
                .OrderByDescending(p => p.UpdatedAt)
                .FirstOrDefaultAsync();

            if (latestProductImg != null && latestProductImg.Link.Equals(productLink))
            {
                return true;
            }
            return false;
        }

        private async Task<ProductImage?> GetImagesIsActiveAsync(Guid productId)
        {
            var productImage = await _repoManager.ProductImage
       .FindByCondition(p => p.Status == ProductImageStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
       .FirstOrDefaultAsync();

            return productImage;
        }

        private async Task<Result<ProductDtoWithPrice>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundWithPriceId(productId);

            return product.OkResultWithPrice();
        }
    }
}
