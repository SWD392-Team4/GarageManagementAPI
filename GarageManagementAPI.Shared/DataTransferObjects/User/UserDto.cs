﻿using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserDto : BaseDto<UserDtoWithRelation>
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Image { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        [EnumDataType(typeof(SystemRole))]
        public SystemRole Role { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string? CitizenIdentification { get; set; }

        public bool? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public Guid? WorkPlaceId { get; set; }
    }
}
