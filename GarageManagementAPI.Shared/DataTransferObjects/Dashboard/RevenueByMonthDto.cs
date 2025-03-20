namespace GarageManagementAPI.Shared.DataTransferObjects.Dashboard
{
    public class RevenueByMonthDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
