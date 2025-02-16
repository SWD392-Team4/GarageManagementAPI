using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Supplier : BaseEntity<Supplier>
    {
        public string Name { get; set; } = null!;

        public string? TaxCode { get; set; }

        public string Address { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Wards { get; set; } = null!;

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string SupplierCategory { get; set; } = null!;

        public virtual ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();
    }

}

