using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;

namespace GarageManagementAPI.Service.Extension
{
    public static class ServiceHistoryExtension
    {
        public static Result<ServiceHistory> OkResult(this ServiceHistory product)
       => Result<ServiceHistory>.Ok(product);

        public static Result<ServiceHistoryDto> OkResult(ServiceHistoryDto productDto)
            => Result<ServiceHistoryDto>.Ok(productDto);

        public static Result<ServiceHistoryDto> CreatedResult(this ServiceHistoryDto productDto)
            => Result<ServiceHistoryDto>.Created(productDto);

        public static Result<ServiceHistory> NotFoundId(this ServiceHistory? product, Guid productId)
            => Result<ServiceHistory>.NotFound([ServiceHistoryErrors.GetServiceHistoryNotFoundWithIdError(productId)]);

        public static Result<ServiceHistoryDto> NotFoundId(Guid productId)
     => Result<ServiceHistoryDto>.NotFound([ServiceHistoryErrors.GetServiceHistoryNotFoundWithIdError(productId)]);

        public static Result<ServiceHistory> NotFoundError()
          => Result<ServiceHistory>.NotFound([ServiceHistoryErrors.GetServiceHistoryNotFoundError()]);
    }
}
