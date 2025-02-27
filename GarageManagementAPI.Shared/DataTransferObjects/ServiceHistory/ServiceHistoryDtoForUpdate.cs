using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory
{
    public record class ServiceHistoryDtoForUpdate : ServiceHistoryDtoForManipulation
    {
        [EnumDataType(typeof(ServiceHistoryStatus))]
        public ServiceHistoryStatus? Status { get; set; } = null;
    }
}
