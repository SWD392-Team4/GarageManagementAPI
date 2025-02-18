﻿using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;
        private readonly Lazy<IDataShaper<Shared.DataTransferObjects.Brand.BrandDto>> _brandShaper;
        private readonly Lazy<IDataShaper<Shared.DataTransferObjects.Product.ProductDto>> _productShaper;
        private readonly Lazy<IDataShaper<Shared.DataTransferObjects.ProductHistory.ProductHistoryDto>> _productHistoryShaper;
        private readonly Lazy<IDataShaper<Shared.DataTransferObjects.ProductCategory.ProductCategoryDto>> _productCategoryShaper;
        private readonly Lazy<IDataShaper<Shared.DataTransferObjects.ProductImage.ProductImageDto>> _productImageShaper;

        public DataShaperManager()
        {
            _workplaceShaper = new Lazy<IDataShaper<WorkplaceDto>>(
                () => new DataShaper<WorkplaceDto>(WorkplaceDto.PropertyInfos));

            _userShaper = new Lazy<IDataShaper<UserDto>>(
               () => new DataShaper<UserDto>(UserDto.PropertyInfos));

            _brandShaper = new Lazy<IDataShaper<Shared.DataTransferObjects.Brand.BrandDto>>(
               () => new DataShaper<Shared.DataTransferObjects.Brand.BrandDto>(Shared.DataTransferObjects.Brand.BrandDto.PropertyInfos));

            _productShaper = new Lazy<IDataShaper<Shared.DataTransferObjects.Product.ProductDto>>(
               () => new DataShaper<Shared.DataTransferObjects.Product.ProductDto>(Shared.DataTransferObjects.Product.ProductDto.PropertyInfos));

            _productHistoryShaper = new Lazy<IDataShaper<Shared.DataTransferObjects.ProductHistory.ProductHistoryDto>>(
              () => new DataShaper<Shared.DataTransferObjects.ProductHistory.ProductHistoryDto>(Shared.DataTransferObjects.ProductHistory.ProductHistoryDto.PropertyInfos));

            _productCategoryShaper = new Lazy<IDataShaper<Shared.DataTransferObjects.ProductCategory.ProductCategoryDto>>(
              () => new DataShaper<Shared.DataTransferObjects.ProductCategory.ProductCategoryDto>(Shared.DataTransferObjects.ProductCategory.ProductCategoryDto.PropertyInfos));

            _productImageShaper = new Lazy<IDataShaper<Shared.DataTransferObjects.ProductImage.ProductImageDto>>(
            () => new DataShaper<Shared.DataTransferObjects.ProductImage.ProductImageDto>(Shared.DataTransferObjects.ProductImage.ProductImageDto.PropertyInfos));
        }

        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;

        public IDataShaper<UserDto> User => _userShaper.Value;

        public IDataShaper<Shared.DataTransferObjects.Brand.BrandDto> Brand => _brandShaper.Value;
        public IDataShaper<Shared.DataTransferObjects.Product.ProductDto> Product => _productShaper.Value;
        public IDataShaper<Shared.DataTransferObjects.ProductCategory.ProductCategoryDto> ProductCategory => _productCategoryShaper.Value;
        public IDataShaper<Shared.DataTransferObjects.ProductHistory.ProductHistoryDto> ProductHistory => _productHistoryShaper.Value;
        public IDataShaper<Shared.DataTransferObjects.ProductImage.ProductImageDto> ProductImage => _productImageShaper.Value;
    }
}
