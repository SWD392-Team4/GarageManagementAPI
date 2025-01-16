using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGarageService
    {
        ApiBaseResponse GetAllGarages(bool trackChanges);

        ApiBaseResponse GetGarage(Guid id, bool trackChanges);

        ApiBaseResponse CreateGarage(GarageForCreationDto garageForCreationDto);

        ApiBaseResponse UpdateGarage(Guid garageId, GarageForUpdateDto garageForUpdateDto, bool trackChanges);
    }
}
