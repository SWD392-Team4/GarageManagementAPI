namespace GarageManagementAPI.Entities.Models
{
    public partial class AppointmentPerDay : BaseEntity<AppointmentPerDay>
    {
        public int CountPerDay { get; set; }

        public Guid GarageId { get; set; }

        public Workplace? Garage { get; set; }

    }
}


