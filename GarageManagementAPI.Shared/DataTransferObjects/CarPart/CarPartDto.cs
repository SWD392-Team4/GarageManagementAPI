using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPart
{
    public record class CarPartDto : BaseDto<CarPartDto>
    {
        public Guid Id { get; set; }
        public string PartName { get; set; } = null!;

        [EnumDataType(typeof(CarPartStatus))]
        public CarPartStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
