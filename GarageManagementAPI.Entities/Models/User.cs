using GarageManagementAPI.Shared.Enum;
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

        public required SystemStatus Status { get; set; }

        public string? Image { get; set; }

        public EmployeeInfo? EmployeeInfo { get; set; }




        [IgnoreDataMember]
        public static readonly PropertyInfo[] PropertyInfos;

        static User()
        {
            PropertyInfos = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
