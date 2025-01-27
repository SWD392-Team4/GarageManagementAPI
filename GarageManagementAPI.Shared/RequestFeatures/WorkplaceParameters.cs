using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class WorkplaceParameters : RequestParameters
    {
        public WorkplaceParameters() => OrderBy = "name";

        public string? Name { get; set; }

        public WorkplaceType? WorkplaceType { get; set; }

        public WorkplaceStatus? WorkplaceStatus { get; set; }
    }
}
