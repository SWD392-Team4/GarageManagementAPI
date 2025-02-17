using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class UserParameters : RequestParameters
    {
        public UserParameters() => OrderBy = "name";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Guid? WorkplaceId { get; set; }

        [EnumDataType(typeof(SystemRole))]
        public SystemRole? Role { get; set; }

    }
}
