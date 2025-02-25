using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory
{
    public record class CarPartCategoryDtoForManipulation
    {
        public string PartCategory { get; set; } = null!;

    }
}
