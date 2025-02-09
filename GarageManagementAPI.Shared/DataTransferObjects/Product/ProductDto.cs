using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDto : BaseDto<ProductDto>
    {
        public Guid Id {get; set; }
        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductDescription { get; set; }
        public Guid BrandId { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
