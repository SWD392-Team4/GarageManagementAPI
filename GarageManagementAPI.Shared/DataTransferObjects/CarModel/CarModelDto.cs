using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarModel
{
    public record CarModelDto : BaseDto<CarModelDto>
    {
        public Guid Id { get; set; }

        public string? BrandName { get; set; }

        public string? BrandLinkLogo { get; set; }

        [EnumDataType(typeof(CarModelStatus))]
        public CarModelStatus? Status { get; set; }

        public string? Category { get; set; }

        public string? ModelName { get; set; }

        public string? ModelYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
