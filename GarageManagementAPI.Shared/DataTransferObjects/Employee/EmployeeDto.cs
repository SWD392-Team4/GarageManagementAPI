using GarageManagementAPI.Shared.Enum;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{
    public record EmployeeDto
    {
        public Guid Id { get; init; }

        public required string Name { get; init; }

        public required string PhoneNumber { get; init; }

        public required string Address { get; init; }

        public DateOnly DateOfBirth { get; init; }

        public bool Gender { get; init; }

        public required string CitizenIdentification { get; init; }

        public required string Email { get; init; }

        public EmployeeStatus Status { get; init; }

        public SystemRole Role { get; init; }

        public Guid GarageId { get; init; }
    }

}
