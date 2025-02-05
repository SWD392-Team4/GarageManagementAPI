using GarageManagementAPI.Shared.CustomAttribute;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Workplace
{
    public record WorkplaceDto : BaseDto<WorkplaceDto>
    {
        [PropertyOrder(1)]
        public required Guid Id { get; init; }

        [PropertyOrder(2)]
        public required string Name { get; init; }

        [PropertyOrder(3)]
        public required string PhoneNumber { get; init; }

        [PropertyOrder(4)]
        public required string FullAddress { get; init; }

        [PropertyOrder(5)]
        [EnumDataType(typeof(WorkplaceType))]
        public WorkplaceType WorkplaceType { get; init; }

        [PropertyOrder(6)]
        [EnumDataType(typeof(WorkplaceStatus))]
        public WorkplaceStatus Status { get; init; }

        [PropertyOrder(7)]
        public DateTimeOffset CreatedAt { get; init; }

        [PropertyOrder(8)]
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
