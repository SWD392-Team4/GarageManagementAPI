﻿using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductImage
{
    public record class ProductImageDtoForUpdate : ProductImageDtoForManipulation
    {
        [EnumDataType(typeof(ProductImageStatus))]
        public ProductImageStatus? Status { get; set; } = ProductImageStatus.None;
    }
}
