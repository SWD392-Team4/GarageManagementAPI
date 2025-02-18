using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductHistory
{
    public record ProductHistoryDtoForUpdate
    {
        [EnumDataType(typeof(ProductHistoryStatus))]
        public ProductHistoryStatus? Status { get; set; } = ProductHistoryStatus.None;
    }
}
