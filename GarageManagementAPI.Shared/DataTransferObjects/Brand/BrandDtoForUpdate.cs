using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record BrandDtoForUpdate : BrandDtoForManipulation
    {
        [EnumDataType(typeof(SystemStatus))]
        public new SystemStatus Status { get; set; }
    }
}
