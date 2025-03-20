namespace GarageManagementAPI.Shared.DataTransferObjects.Dashboard
{
    public class ServiceStatisticsDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EstimatedHours { get; set; } = 0;
        public decimal TotalRevenue { get; set; } = 0;

        public int TotalUsed { get; set; } = 0;
    }
}
