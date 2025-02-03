using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record EmployeeInfoDto : BaseDto<EmployeeInfoDto>
    {
        public string? CitizenIdentification { get; set; }

        public bool Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        [EnumDataType(typeof(WorkplaceType))]
        public WorkplaceType WorkPlaceType { get; set; }
    }
}
