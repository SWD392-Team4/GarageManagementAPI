using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ProductImg;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceImage;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;

namespace GarageManagementAPI.Service.Extension
{
    public static class ServiceImageExtension
    {
        public static Result<ServiceImage> OkResult(this ServiceImage serviceImage)
         => Result<ServiceImage>.Ok(serviceImage);

        public static Result<ServiceImageDto> CreatedResult(this ServiceImageDto serviceImageDto)
            => Result<ServiceImageDto>.Created(serviceImageDto);

        public static Result<ServiceImage> NotFoundId(this ServiceImage? serviceImage, Guid serviceId)
            => Result<ServiceImage>.NotFound([ServiceImageErrors.GetServiceImageNotFoundWithIdError(serviceId)]);

        public static Result<ServiceImage> NotFoundError()
          => Result<ServiceImage>.NotFound([ProductImgErrors.GetProductImageNotFoundError()]);
    }
}
