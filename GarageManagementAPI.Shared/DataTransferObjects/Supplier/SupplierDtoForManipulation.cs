namespace GarageManagementAPI.Shared.DataTransferObjects.Supplier
{
    public record class SupplierDtoForManipulation
    {
        public string Name { get; set; } = null!;
        public string? TaxCode { get; set; }
        public string Address { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Wards { get; set; } = null!;
        public string SupplierCategory { get; set; } = null!;
    }
}
