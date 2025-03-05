using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack
{

    public record PackageFeedBackDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid CustomerFullName { get; set; }

        public Guid PackageId { get; set; }

        public string? FeedBack { get; set; }

        public string? Emoji { get; set; }

        [EnumDataType(typeof(PackageFeedBackStatus))]
        public PackageFeedBackStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
