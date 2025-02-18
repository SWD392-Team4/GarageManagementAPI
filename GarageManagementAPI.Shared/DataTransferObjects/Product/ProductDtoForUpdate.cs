using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus? Status { get; set; } = ProductStatus.Inactive;
    }
}
