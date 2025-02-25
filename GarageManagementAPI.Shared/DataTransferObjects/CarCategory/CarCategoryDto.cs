using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarCategory
{
    public record CarCategoryDto
    {
        public Guid Id { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        [EnumDataType(typeof(CarCategoryStatus))]
        public CarCategoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
