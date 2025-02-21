using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.Service;

namespace GarageManagementAPI.Service.Extension
{
    public static class ServiceExtension
    {
        public static Result<Entities.Models.Service> OkResult(this Entities.Models.Service Service)
        => Result<Entities.Models.Service>.Ok(Service);

        public static Result<ServiceDto> OkResult(this ServiceDto ServiceDto)
            => Result<ServiceDto>.Ok(ServiceDto);

        public static Result<ServiceDto> CreatedResult(this ServiceDto ServiceDto)
            => Result<ServiceDto>.Created(ServiceDto);

        public static Result<Entities.Models.Service> NotFound(this Entities.Models.Service? Service, Guid ServiceId)
            => Result<Entities.Models.Service>.NotFound([ServiceErrors.GetServiceNotFoundError(ServiceId)]);
    }
}
