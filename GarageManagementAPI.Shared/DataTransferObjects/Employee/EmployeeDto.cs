using GarageManagementAPI.Shared.CustomAttribute;


namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{
    public record EmployeeDto : BaseDto<EmployeeDtoWithRelation>
    {
        [PropertyOrder(1)]
        public Guid Id { get; init; }

        [PropertyOrder(2)]
        public required string Name { get; init; }

        [PropertyOrder(3)]
        public required string PhoneNumber { get; init; }

        [PropertyOrder(4)]
        public required string Address { get; init; }

        [PropertyOrder(5)]
        public DateOnly DateOfBirth { get; init; }

        [PropertyOrder(6)]
        public bool Gender { get; init; }

        [PropertyOrder(7)]
        public required string CitizenIdentification { get; init; }

        [PropertyOrder(8)]
        public required string Email { get; init; }

        [PropertyOrder(9)]
        public required string Status { get; init; }

        [PropertyOrder(10)]
        public required string Role { get; init; }

        [PropertyOrder(11)]
        public required string GarageId { get; init; }

    }


}
