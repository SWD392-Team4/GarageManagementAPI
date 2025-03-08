using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class CarModelParameters : RequestParameters
    {
        public Guid? BrandId { get; set; }

        public Guid? CarCategoryId { get; set; }

        public string? ModelName { get; set; }

        public int? ModelYear { get; set; }

        [EnumDataType(typeof(CarModelStatus))]
        public CarModelStatus? Status { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
