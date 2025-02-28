using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback
{
    public record class ServiceFeedBackDto : BaseDto<ServiceFeedBackDto>
    {
        public Guid Id { get; set; }
        public string FeedBack { get; set; } = null!;
        public string Emoji { get; set; } = null!;
        [EnumDataType(typeof(ServiceFeedBackStatus))]
        public ServiceFeedBackStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
