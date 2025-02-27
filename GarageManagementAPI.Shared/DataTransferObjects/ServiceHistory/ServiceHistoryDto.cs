using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory
{
    public record class ServiceHistoryDto : BaseDto<ServiceHistoryDto>
    {
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
