using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ServiceFeedBackParameters : RequestParameters
    {
        public ServiceFeedBackParameters() => OrderBy = "CreatedAt";
        public string FeedBack { get; set; } = null!;
        public string Emoji { get; set; } = null!;
        [EnumDataType(typeof(ServiceFeedBackStatus))]
        public ServiceFeedBackStatus? Status { get; set; } = null;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
