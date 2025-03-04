using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class SupplierParameters : RequestParameters
    {
        public SupplierParameters() => OrderBy = "Name";
        public string Name { get; set; } = null!;

        public string? TaxCode { get; set; }

        public string Address { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Wards { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
        [EnumDataType(typeof(SupplierStatus))]
        public SupplierStatus? Status { get; set; } = null;
    }
}
