using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarModel
{
    public record CarModelDto : BaseDto<CarModelDto>
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }

        public string? BrandLinkLogo { get; set; }

        [EnumDataType(typeof(CarModelStatus))]
        public CarModelStatus? Status { get; set; }

        public Guid CarCategoryId { get; set; }
        public string? CarCategory { get; set; }

        public string? ModelName { get; set; }

        public string? ModelYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
