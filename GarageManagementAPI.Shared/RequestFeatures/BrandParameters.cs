namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class BrandParameters : RequestParameters
    {
        public BrandParameters() => OrderBy = "name";
        public string BrandName { get; set; } = null!;

    }
}

