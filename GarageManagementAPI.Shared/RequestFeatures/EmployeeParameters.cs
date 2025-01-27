namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class EmployeeParameters : RequestParameters
    {
        public EmployeeParameters() => OrderBy = "name";

        public string? SearchTerm { get; set; }

        public Guid? WorkplaceId { get; set; }


    }
}
