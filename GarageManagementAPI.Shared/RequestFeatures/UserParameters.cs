namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class UserParameters : RequestParameters
    {
        public UserParameters() => OrderBy = "name";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Guid? WorkplaceId { get; set; }

    }
}
