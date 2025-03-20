namespace GarageManagementAPI.Shared.DataTransferObjects.Dashboard
{
    public class PackageStatisticsDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }  
        public string? Description { get; set; }  
        public decimal TotalRevenue { get; set; } = 0;
        public int TotalUsed { get; set; } = 0;
    }
}
