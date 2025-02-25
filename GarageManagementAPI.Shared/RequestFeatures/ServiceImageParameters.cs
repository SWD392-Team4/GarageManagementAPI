using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ServiceImageParameters : RequestParameters
    {
        public ServiceImageParameters() => OrderBy = "Link";
        [EnumDataType(typeof(ServiceImageStatus))]
        public ServiceImageStatus Status { get; set; }
    }
}
