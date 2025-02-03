
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForRegistrationEmployeeDto : UserForRegistrationDto
    {
        [EnumDataType(typeof(SystemRole), ErrorMessage = UserErrors.RoleInvalid)]
        public SystemRole Role { get; set; }

        public string? CitizenIdentification { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public Guid? WorkplaceId { get; set; }
    }
}
