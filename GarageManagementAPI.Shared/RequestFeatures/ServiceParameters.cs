using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ServiceParameters : RequestParameters
    {
        public ServiceParameters() => OrderBy = "category";
        public string? ServiceName { get; set; }
        public string? CarPartName { get; set; }
        public string? CarCategoryName { get; set; }

        [EnumDataType(typeof(WorkNature))]
        public WorkNature? WorkNature { get; set; }

        [EnumDataType(typeof(ServiceAction))]
        public ServiceAction? Action { get; set; }
        public int? EstimatedHours { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        [EnumDataType(typeof(ServiceStatus))]
        public ServiceStatus? Status { get; set; }
    }
}
