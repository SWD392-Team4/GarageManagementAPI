using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack
{
    public record PackageFeedBackDtoForUpdate : PackageFeedBackDtoForManipulation
    {
        [EnumDataType(typeof(PackageFeedBackStatus))]
        public PackageFeedBackStatus Status { get; set; }
    }
}
