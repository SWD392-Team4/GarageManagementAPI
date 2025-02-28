using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceFeedback;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;

namespace GarageManagementAPI.Service.Extension
{
    public static class ServiceFeedbackExtension
    {
        public static Result<ServiceFeedBack> OkResult(this ServiceFeedBack ServiceFeedBack)
          => Result<ServiceFeedBack>.Ok(ServiceFeedBack);

        public static Result<ServiceFeedBackDto> OkResult(this ServiceFeedBackDto serviceFeedBackDto)
            => Result<ServiceFeedBackDto>.Ok(serviceFeedBackDto);

        public static Result<ServiceFeedBackDto> CreatedResult(this ServiceFeedBackDto serviceFeedBackDto)
            => Result<ServiceFeedBackDto>.Created(serviceFeedBackDto);

        public static Result<ServiceFeedBack> NotFound(this ServiceFeedBack? serviceFeedBack, Guid serviceFeedBackId)
            => Result<ServiceFeedBack>.NotFound([ServiceFeebackErrors.GetServiceFeedbackNotFoundWithIdError(serviceFeedBackId)]);
    }
}
