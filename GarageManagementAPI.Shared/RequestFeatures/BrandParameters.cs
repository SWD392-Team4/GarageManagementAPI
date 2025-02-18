using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class BrandParameters : RequestParameters
    {
        public BrandParameters() => OrderBy = "BrandName";
        public string BrandName { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }

        [EnumDataType(typeof(BrandStatus))]
        public BrandStatus? Status { get; set; } = null;
    }
}

