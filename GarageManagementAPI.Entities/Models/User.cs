using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Runtime.Serialization;

namespace GarageManagementAPI.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public required string Status { get; set; }

        public string? Image { get; set; }

        public EmployeeInfo? EmployeeInfo { get; set; }

        public ICollection<FeedBackService>? FeedBacksService { get; set; }

        public ICollection<FeedBackPackage>? FeedBacksPackage { get; set; }

        public ICollection<CustomerCar>? CustomerCars { get; set; }

        public ICollection<InvoiceAppointment>? InvoiceAppointments { get; set; }

        public ICollection<EmployeeSchedule>? EmployeeSchedules { get; set; }

        public ICollection<GoodsIssued>? GoodsIssueds { get; set; }

        public ICollection<GoodsReceived>? GoodsReceiveds { get; set; }

        public ICollection<InvoiceSell>? InvoiceSells { get; set; }



        [IgnoreDataMember]
        public static readonly PropertyInfo[] PropertyInfos;

        static User()
        {
            PropertyInfos = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
