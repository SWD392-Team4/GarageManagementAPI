namespace GarageManagementAPI.Shared.DataTransferObjects.ReplacementPart_ProductAtGarage
{
    public record ReplacementPart_ProductAtGarageDto
    {
        public Guid ProductAtGarageId { get; set; }
        public Guid ReplacementPartId { get; set; }
        public int QuantityUsed { get; set; }
    }
}
