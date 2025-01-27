using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class GarageParameters : RequestParameters
    {
        public GarageParameters() => OrderBy = "name";

        public string? SearchTerm { get; set; }

        public WorkplaceType? WorkplaceType { get; set; }
    }
}
