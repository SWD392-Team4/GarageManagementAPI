using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGarageService
    {
        Task<ApiBaseResponse> GetAllGaragesAsync(bool trackChanges);

        Task<ApiBaseResponse> GetGarageAsync(Guid garageId, bool trackChanges);

        Task<ApiBaseResponse> CreateGarageAsync(GarageForCreationDto garageForCreationDto);

        Task<ApiBaseResponse> UpdateGarageAsync(
            Guid garageId,
            GarageForUpdateDto garageForUpdateDto,
            bool trackChanges);

        Task<ApiBaseResponse> GetGarageForPatchAsync(
            Guid garageId,
            bool trackChanges);
    }
}
