using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.Supplier
{
    public record class SupplierDto : BaseDto<SupplierDto>
    {
        public required Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string? TaxCode { get; set; }

        public string Address { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Wards { get; set; } = null!;

        [EnumDataType(typeof(SupplierStatus))]
        public SupplierStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string SupplierCategory { get; set; } = null!;
    }
}
