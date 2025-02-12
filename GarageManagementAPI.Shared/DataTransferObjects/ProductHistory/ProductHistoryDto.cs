using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.ProductHistory
{
    public record class ProductHistoryDto : BaseDto<ProductHistoryDto>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        [EnumDataType(typeof(ProductHistoryStatus))]
        public ProductHistoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
