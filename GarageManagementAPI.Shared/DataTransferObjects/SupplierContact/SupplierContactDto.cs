using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.SupplierContact
{
    public record class SupplierContactDto : BaseDto<SupplierContactDto>
    {
        public Guid Id { get; set; }
        public Guid? SupplierId { get; set; }

        public string ContactPersonName { get; set; } = null!;

        public string ContactPosition { get; set; } = null!;

        public string ContactPhoneNumber { get; set; } = null!;

        public string ContactEmail { get; set; } = null!;

        [EnumDataType(typeof(SupplierContactStatus))]
        public SupplierContactStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
