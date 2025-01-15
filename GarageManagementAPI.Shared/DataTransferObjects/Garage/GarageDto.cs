namespace GarageManagementAPI.Shared.DataTransferObjects.Garage
{
    public record GarageDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }

        public required string Address { get; init; }

        public required string City { get; init; }

        public required string PhoneNumber { get; init; }
    }
}
