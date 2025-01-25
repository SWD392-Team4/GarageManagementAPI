namespace GarageManagementAPI.Entities.NewModels
{
    public class Garage : BaseEntity<Garage>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string PhoneNumber { get; set; }

        public ICollection<EmployeeInfo>? EmployeesInfo { get; set; }

    }
}
