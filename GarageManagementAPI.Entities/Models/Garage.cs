namespace GarageManagementAPI.Entities.Models
{
    public class Garage : BaseEntity<Garage>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string PhoneNumber { get; set; }

        public ICollection<EmployeeInfo>? EmployeesInfo { get; set; }

        public ICollection<InvoiceAppointment>? InvoiceAppointments { get; set; }

        public ICollection<ProductAtStore>? ProductAtStores { get; set; }

        public ICollection<GoodsIssued>? GoodsIssueds { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public ICollection<InvoiceSell>? InvoiceSells { get; set; }
    }
}
