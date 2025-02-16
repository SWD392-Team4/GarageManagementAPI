using GarageManagementAPI.Shared.DataTransferObjects;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGarageService
    {
        IEnumerable<GarageDto> GetAllGarages(bool trackChanges);
    }
}
