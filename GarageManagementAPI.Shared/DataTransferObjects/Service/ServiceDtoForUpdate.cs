using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Service
{
    public record class ServiceDtoForUpdate : ServiceDtoForManipulation
    {
        [EnumDataType(typeof(ServiceStatus))]
        public ServiceStatus Status { get; set; }
    }
}
