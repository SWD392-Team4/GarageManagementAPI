using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceImage
{
    public record class ServiceImageDtoForUpdate
    {
        [EnumDataType(typeof(ServiceImageStatus))]
        public ServiceImageStatus Status { get; set; }
    }
}
