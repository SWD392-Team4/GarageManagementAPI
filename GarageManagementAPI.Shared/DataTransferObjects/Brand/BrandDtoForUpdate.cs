using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record class BrandDtoForUpdate : BrandDtoForManipulation
    {
        [EnumDataType(typeof(BrandStatus))]
        public BrandStatus Status { get; set; }
    }
}
