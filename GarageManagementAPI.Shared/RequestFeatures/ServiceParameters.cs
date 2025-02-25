using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ServiceParameters : RequestParameters
    {
        public ServiceParameters() => OrderBy = "category";
        public string ServiceName { get; set; } = null!;
        public string CarPartName { get; set; } = null!;
        public string CarCategoryName {  get; set; } = null!;
        public string WorkNature { get; set; } = null!;
        public string Action { get; set; } = null!;
        public int EstimatedHours { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        [EnumDataType(typeof(ServiceStatus))]
        public ServiceStatus? Status { get; set; } = null;
    }
}
