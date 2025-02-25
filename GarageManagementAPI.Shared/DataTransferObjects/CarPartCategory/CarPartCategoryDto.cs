using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory
{
    public record class CarPartCategoryDto : BaseDto<CarPartCategoryDto>
    {
        public Guid Id { get; set; }
        public string PartCategory { get; set; } = null!;

        [EnumDataType(typeof(CarPartCategoryStatus))]
        public CarPartCategoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
