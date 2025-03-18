using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/appointments/{appointmentId:guid}/appointment-details")]
    [ApiController]
    public class CarConditionImageController : ApiControllerBase
    {
        public CarConditionImageController(IServiceManager service) : base(service)
        {
        }
        [HttpGet("{detailId:guid}/car-conditions")]
        public async Task<IActionResult> GetCarConditionImages(Guid appointmentId, Guid detailId, [FromQuery] CarConditionImageParameters carConditionImageParameters)
        {
            var result = await _service.CarConditionImage.GetCarConditionImageByAppointmentDetailIdAsync(appointmentId, detailId, carConditionImageParameters);
            return result.Map(
                onSuccess: result =>
                {
                    return Ok(result);
                },
                onFailure: ProcessError
                );
        }

        [HttpGet("{detailId:guid}/car-conditions/{carConditionId:guid}")]
        public async Task<IActionResult> GetCarConditionImage(Guid appointmentId, Guid detailId, Guid carConditionId)
        {
            var result = await _service.CarConditionImage.GetCarConditionImageByIdAsync(appointmentId, detailId, carConditionId);
            return result.Map(
                onSuccess: result =>
                {
                    return Ok(result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPost("{detailId:guid}/car-conditions/before")]
        public async Task<IActionResult> CreateCarConditionImagesBefore(Guid appointmentId, Guid detailId, [FromForm] IList<IFormFile> formFileDtos)
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

            var result = await _service.CarConditionImage.CreateCarConditionImageAsync(appointmentId, detailId, imagePublicIds!, Shared.Enums.ConditionStage.Before);

            return result.Map(
                onSuccess: result =>
                {
                    return CreatedAtAction(nameof(GetCarConditionImages), new { appointmentId, detailId, CarConditionImageParameters = new CarConditionImageParameters() { Stage = ConditionStage.Before } }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPost("{detailId:guid}/car-conditions/after")]
        public async Task<IActionResult> CreateCarConditionImagesAfter(Guid appointmentId, Guid detailId, [FromForm] IList<IFormFile> formFileDtos)
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

            var result = await _service.CarConditionImage.CreateCarConditionImageAsync(appointmentId, detailId, imagePublicIds!, ConditionStage.After);

            return result.Map(
                onSuccess: result =>
                {
                    return CreatedAtAction(nameof(GetCarConditionImages), new { appointmentId, detailId, CarConditionImageParameters = new CarConditionImageParameters() { Stage = ConditionStage.After } }, result);
                },
                onFailure: ProcessError
                );
        }
    }
}
