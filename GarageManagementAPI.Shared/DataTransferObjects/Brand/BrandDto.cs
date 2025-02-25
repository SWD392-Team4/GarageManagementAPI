using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record class BrandDto : BaseDto<BrandDto>
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = null!;
        public string LogoLink { get; set; } = null!;

        [EnumDataType(typeof(BrandStatus))]
        public BrandStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
