using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/packages/{packageId:guid}/images")]
    [ApiController]
    public class PackageImageController : ApiControllerBase
    {
        public PackageImageController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPackageImages(Guid packageId, [FromQuery] PackageImageParameters packageImageParameters)
        {
            var packageImages = await _service.PackageImageService.GetPackageImageByPackageIdAsync(packageId, packageImageParameters);
            return packageImages.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> CreatePackageImage(Guid packageId, [FromForm] IList<IFormFile> formFileDtos)
        {
            if (formFileDtos is not null && formFileDtos.Count >= 5)
                return BadRequest(Result.BadRequest(RequestErrors.GetTooManyImageUploadErrors()));

            var imagePublicIds = new List<(string? ImageId, string? ImageLink)>();

            if (formFileDtos is not null)
            {
                foreach (var image in formFileDtos)
                {
                    var uploadImageResult = await _service.MediaService.UploadPackageImageAsync(image);
                    if (!uploadImageResult.IsSuccess)
                        return ProcessError(uploadImageResult);

                    var imgTuple = uploadImageResult.GetValue<(string? ImageId, string? ImageLink)>();
                    imagePublicIds.Add(imgTuple);
                }
            }

            var result = await _service.PackageImageService.CreatePackageImageAsync(packageId, imagePublicIds!);

            return result.Map(
                onSuccess: _ => Created(),
                onFailure: ProcessError
                );
        }

        [HttpDelete("{packageImageId:guid}")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> RemovePackageImage(Guid packageId, Guid packageImageId)
        {
            var packageImageDtoResult = await _service.PackageImageService.GetPackageImageByIdAsync(packageId, packageImageId);
            if (!packageImageDtoResult.IsSuccess)
                return ProcessError(packageImageDtoResult);


            var packageDto = packageImageDtoResult.GetValue<PackageImageDto>();
            await _service.MediaService.RemoveImage(packageDto.ImageId!);

            var result = await _service.PackageImageService.RemovePackageImageAsync(packageId, packageImageId);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpDelete]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> RemoveAllPackageImage(Guid packageId)
        {
            var packageImages = await _service.PackageImageService.GetPackageImageByPackageIdAsync(packageId);

            if (!packageImages.IsSuccess)
                return ProcessError(packageImages);

            foreach (var packageImage in packageImages.GetValue<IEnumerable<PackageImageDto>>())
            {
                await _service.MediaService.RemoveImage(packageImage.ImageId!);
            }

            var result = await _service.PackageImageService.RemoveAllPackageImageOfPackageAsync(packageId);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }
    }
}
