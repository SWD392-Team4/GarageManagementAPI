using GarageManagementAPI.Entities.NewModels;

namespace GarageManagementAPI.Entities.Models
{
    public class EmployeeInfo : BaseEntity<EmployeeInfo>
    {
        public required Guid GarageId { get; set; }

        public required string CitizenIdentification { get; set; }

        public required bool Gender { get; set; }

        public required DateOnly DateOfBirth { get; set; }

        public Garage? Garage { get; set; }

        public User? User { get; set; }

    }
}
