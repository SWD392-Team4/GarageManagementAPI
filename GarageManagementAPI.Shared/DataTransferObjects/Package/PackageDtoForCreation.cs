using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDtoForCreation : PackageDtoForManipulation
    {
        public IEnumerable<Guid>? ServiceList { get; set; }

        public IEnumerable<PackageConditionDtoForCreation>? PackageConditions { get; set; }
    }
}
