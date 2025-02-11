using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record BrandDtoForUpdate : BrandDtoForManipulation
    {
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }
    }
}
