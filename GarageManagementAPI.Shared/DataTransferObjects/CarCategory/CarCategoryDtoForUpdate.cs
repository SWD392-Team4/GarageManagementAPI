using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarCategory
{
    public record CarCategoryDtoForUpdate : CarCategoryDtoForManipulation
    {
        [EnumDataType(typeof(CarCategoryStatus))]
        public CarCategoryStatus Status { get; set; }
    }
}
