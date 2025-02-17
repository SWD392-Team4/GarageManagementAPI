using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace GarageManagementAPI.Entities.Models
{
    public partial class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public string? ImageLink { get; set; } = "N/A";

        public string? ImageId { get; set; } = "N/A";

        [EnumDataType(typeof(UserStatus))]
        public UserStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<AppointmentDetailPackage> AppointmentDetailPackageUpdateByCustomers { get; set; } = new List<AppointmentDetailPackage>();

        public virtual ICollection<AppointmentDetailPackage> AppointmentDetailPackageUpdateByEmployees { get; set; } = new List<AppointmentDetailPackage>();

        public virtual ICollection<AppointmentDetail> AppointmentDetailUpdateByCustomers { get; set; } = new List<AppointmentDetail>();

        public virtual ICollection<AppointmentDetail> AppointmentDetailUpdateByEmployees { get; set; } = new List<AppointmentDetail>();

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<CustomerCar> CustomerCarCreatedByEmployees { get; set; } = new List<CustomerCar>();

        public virtual ICollection<CustomerCar> CustomerCarCustomers { get; set; } = new List<CustomerCar>();

        public virtual EmployeeInfo? EmployeeInfo { get; set; }

        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new List<EmployeeSchedule>();

        public virtual ICollection<GoodsIssued> GoodsIssueds { get; set; } = new List<GoodsIssued>();

        public virtual ICollection<GoodsReceived> GoodsReceiveds { get; set; } = new List<GoodsReceived>();

        public virtual ICollection<Invoice> InvoiceCustomers { get; set; } = new List<Invoice>();

        public virtual ICollection<Invoice> InvoiceEmployees { get; set; } = new List<Invoice>();

        public virtual ICollection<PackageFeedBack> PackageFeedBacks { get; set; } = new List<PackageFeedBack>();

        public virtual ICollection<ServiceFeedBack> ServiceFeedBacks { get; set; } = new List<ServiceFeedBack>();

        public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

        [IgnoreDataMember]
        public static readonly PropertyInfo[] PropertyInfos;

        static User()
        {
            PropertyInfos = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}


