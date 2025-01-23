using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGarageService
    {
        Task<Result> GetAllGaragesAsync(
            GarageParameters garageParameters,
            bool trackChanges);

        Task<Result> GetGarageAsync(
            Guid garageId,
            GarageParameters garageParameters,
            bool trackChanges);

        Task<Result> CreateGarageAsync(GarageForCreationDto garageForCreationDto);

        Task<Result> UpdateGarageAsync(
            Guid garageId,
            GarageForUpdateDto garageForUpdateDto,
            bool trackChanges);

        Task<Result> GetGarageForPatchAsync(
            Guid garageId,
            bool trackChanges);
    }
}
