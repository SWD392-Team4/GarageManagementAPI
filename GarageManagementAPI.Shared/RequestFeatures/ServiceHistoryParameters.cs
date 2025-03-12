using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ServiceHistoryParameters : RequestParameters
    {
        public ServiceHistoryParameters() => OrderBy = "Price";
        public decimal Price { get; set; }

    }
}
