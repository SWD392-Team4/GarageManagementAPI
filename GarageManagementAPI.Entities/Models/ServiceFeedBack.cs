using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ServiceFeedBack : BaseEntity<ServiceFeedBack>
    {
        public Guid CustomerId { get; set; }
        public Guid ServiceId { get; set; }
        public string FeedBack { get; set; } = null!;
        public string Emoji { get; set; } = null!;
        [EnumDataType(typeof(ServiceFeedBackStatus))]
        public ServiceFeedBackStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual User Customer { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }

}

