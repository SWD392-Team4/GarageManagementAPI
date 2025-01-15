using GarageManagementAPI.Shared.Enum;

namespace GarageManagementAPI.Entities.Models
{
    public class Employee : BaseEntity
    {
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Address { get; set; }

        public required DateOnly DateOfBirth { get; set; }

        public required bool Gender { get; set; }

        public required string CitizenIdentification { get; set; }

        public required string Email { get; set; }

        public required EmployeeStatus Status { get; set; }

        public required SystemRole Role { get; set; }

        public Guid CompanyId { get; set; }

        public Garage? Garage { get; set; }

    }
}
