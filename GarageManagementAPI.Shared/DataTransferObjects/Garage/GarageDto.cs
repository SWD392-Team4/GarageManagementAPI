using GarageManagementAPI.Shared.CustomAttribute;
using System.Text.Json.Serialization;

namespace GarageManagementAPI.Shared.DataTransferObjects.Garage
{
    public record GarageDto : BaseDto<GarageDtoWithRelation>
    {
        [PropertyOrder(1)]
        public required Guid Id { get; init; }

        [PropertyOrder(2)]
        public required string Name { get; init; }

        [PropertyOrder(3)]
        public required string Address { get; init; }

        [PropertyOrder(4)]
        public required string City { get; init; }

        [PropertyOrder(5)]
        public required string PhoneNumber { get; init; }

    }
}
