namespace GarageManagementAPI.Shared.DataTransferObjects.SupplierContact
{
    public record class SupplierContactDtoForManipulation
    {
        public Guid SupplierId { get; set; }
        public string ContactPersonName { get; set; } = null!;

        public string ContactPosition { get; set; } = null!;

        public string ContactPhoneNumber { get; set; } = null!;

        public string ContactEmail { get; set; } = null!;
    }
}
