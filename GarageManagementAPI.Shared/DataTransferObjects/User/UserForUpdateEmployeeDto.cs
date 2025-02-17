using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForUpdateEmployeeDto : UserForUpdateDto
    {
        public string? CitizenIdentification { get; set; }

        public bool? Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }

        [EnumDataType(typeof(UserStatus))]
        public UserStatus? Status { get; set; }

        public Guid? WorkplaceId { get; set; }
    }
}
