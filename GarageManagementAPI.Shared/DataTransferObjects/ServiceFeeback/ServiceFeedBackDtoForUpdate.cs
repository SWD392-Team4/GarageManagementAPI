using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback
{
    public record class ServiceFeedBackDtoForUpdate : ServiceFeedBackDtoForManipulation
    {
        [EnumDataType(typeof(ServiceFeedBackStatus))]
        public ServiceFeedBackStatus Status { get; set; }
    }
}
