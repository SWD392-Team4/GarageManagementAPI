using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments/{appointmentId:guid}/details")]
    [ApiController]
    public class AppointmentDetailController : ApiControllerBase
    {
        public AppointmentDetailController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetails(Guid garageId, Guid appointmentId)
        {
            var result = await _service.AppointmentDetailService.GetAppointmentDetailsAsync(garageId, appointmentId);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] List<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreation)
        {
            var result = await _service.AppointmentDetailService.CreateAppointmentDetails(garageId, appointmentId, appointmentDetailDtoForCreation);
            return result.Map(
                onSuccess: _ => Created(),
                onFailure: ProcessError
                );
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var result = await _service.AppointmentDetailService.CancelAppointmentDetailsAsync(garageId, appointmentId, appointmentDetailDtoForCancellation);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("reject")]
        public async Task<IActionResult> RejectAppointmentDetail(Guid garageId, Guid appointmentId, [FromBody] AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var result = await _service.AppointmentDetailService.RejectAppointmentDetailsAsync(garageId, appointmentId, appointmentDetailDtoForCancellation);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{detailId:guid}/car-conditions")]

        [HttpPost("{detailId:guid}/car-conditions/before")]
        public async Task<IActionResult> CreateCarConditionImages(Guid garageId, Guid appointmentId, Guid detailId,[FromForm] IList<IFormFile> formFileDtos)
        {
            if (formFileDtos is not null && formFileDtos.Count > 5)
                return BadRequest(Result.BadRequest(RequestErrors.GetTooManyImageUploadErrors()));

            var imagePublicIds = new List<(string? ImageId, string? ImageLink)>();

            if (formFileDtos is not null)
            {
                foreach (var image in formFileDtos)
                {
                    var uploadImageResult = await _service.MediaService.UploadCarConditionImageAsync(image);
                    if (!uploadImageResult.IsSuccess)
                        return ProcessError(uploadImageResult);

                    var imgTuple = uploadImageResult.GetValue<(string? ImageId, string? ImageLink)>();
                    imagePublicIds.Add(imgTuple);
                }
            }

            var result = await _service.CarConditionImage.CreatePackageImageAsync(garageId, appointmentId, detailId, imagePublicIds!, Shared.Enums.ConditionStage.Before);

            return result.Map(
                onSuccess: result =>
                {
                    return CreatedAtAction(nameof(GetPackageImages), new { packageId }, result);
                },
                onFailure: ProcessError
                );
        }

    }
}
