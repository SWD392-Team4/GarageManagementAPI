using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPart
{
    public record class CarPartDtoForManipulation
    {
        public string PartName { get; set; } = null!;
        [EnumDataType(typeof(CarPartStatus))]
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
