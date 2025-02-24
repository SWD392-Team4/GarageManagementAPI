using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarModel
{
    public record CarModelDtoForUpdate : CarModelDtoForManipulation
    {
        [EnumDataType(typeof(CarModelStatus))]
        public CarModelStatus Status { get; set; }
    }
}
