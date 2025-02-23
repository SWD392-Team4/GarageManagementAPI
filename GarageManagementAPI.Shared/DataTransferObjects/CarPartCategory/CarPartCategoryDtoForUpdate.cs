using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory
{
    public record class CarPartCategoryDtoForUpdate : CarPartCategoryDtoForManipulation
    {
        [EnumDataType(typeof(CarPartCategoryStatus))]
        public CarPartCategoryStatus Status { get; set; }
    }
}
