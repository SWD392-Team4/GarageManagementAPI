using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class CarPartCategoryParameters : RequestParameters
    {
        public string PartCategory { get; set; } = null!;

        [EnumDataType(typeof(CarPartCategoryStatus))]
        public CarPartCategoryStatus? Status { get; set; } = null;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
