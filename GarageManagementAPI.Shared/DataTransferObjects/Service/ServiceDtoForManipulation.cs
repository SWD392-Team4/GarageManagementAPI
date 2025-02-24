namespace GarageManagementAPI.Shared.DataTransferObjects.Service
{
    public record class ServiceDtoForManipulation
    {
        public Guid CarPartId { get; set; }

        public Guid CarCategoryId { get; set; }

        public string ServiceCategory { get; set; } = null!;

        public string ServiceName { get; set; } = null!;

        public string WorkNature { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int EstimatedHours { get; set; }

    }
}
