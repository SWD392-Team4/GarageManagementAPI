using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarPart
{
    public record class CarPartDtoForUpdate : CarPartDtoForManipulation
    {
        public CarPartStatus Status { get; set; }
    }
}
