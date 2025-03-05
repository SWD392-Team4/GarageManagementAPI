using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ApiControllerBase
    {
        public PackageController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPackage([FromQuery] PackageParameters packageParameters)
        {
            var result = await _service.PackageService
                .GetPackagesAsync(packageParameters, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{packageId:guid}", Name = "GetPackageById")]
        public async Task<IActionResult> GetPackageById(Guid packageId, [FromQuery] PackageParameters packageParameters)
        {
            var result = await _service.PackageService
                .GetPackageByIdAsync(packageId, false);

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPost(Name = "CreatePacakge")]
        public async Task<IActionResult> CreatePacakge([FromForm] IList<IFormFile>? imagePackage, [FromForm] PackageDtoForCreation packageDtoForCreationompany)
        {
            if (imagePackage is not null && imagePackage.Count >= 5)
                return BadRequest(Result.BadRequest(RequestErrors.GetTooManyImageUploadErrors()));

            var imagePublicIds = new List<(string? publicId, string? absoluteUrl)>();

            if (imagePackage is not null)
            {
                foreach (var image in imagePackage)
                {
                    var uploadImageResult = await _service.MediaService.UploadPackageImageAsync(image);
                    if (!uploadImageResult.IsSuccess)
                        return ProcessError(uploadImageResult);

                    var imgTuple = uploadImageResult.GetValue<(string? publicId, string? absoluteUrl)>();
                    imagePublicIds.Add(imgTuple);
                }
            }
            var result = await _service.PackageService.CreatePackage(packageDtoForCreationompany, imagePublicIds);

            return result.Map(
                onSuccess: result =>
                {
                    var createdPackage = result.GetValue<PackageDto>();

                    return CreatedAtRoute("GetPackageById", new { packageId = createdPackage.Id }, result);
                },
                onFailure: ProcessError
            );
        }

        [HttpPut("{packageId:guid}", Name = "UpdatePackage")]
        public async Task<IActionResult> UpdatePackage(Guid packageId, [FromForm] IList<IFormFile>? imagePackage, [FromForm] PackageDtoForUpdate packageDtoForUpdate)
        {
            if (imagePackage is not null && imagePackage.Count >= 5)
                return BadRequest(Result.BadRequest(RequestErrors.GetTooManyImageUploadErrors()));
            var imagePublicIds = new List<(string? publicId, string? absoluteUrl)>();
            if (imagePackage is not null)
            {
                foreach (var image in imagePackage)
                {
                    var uploadImageResult = await _service.MediaService.UploadPackageImageAsync(image);
                    if (!uploadImageResult.IsSuccess)
                        return ProcessError(uploadImageResult);
                    var imgTuple = uploadImageResult.GetValue<(string? publicId, string? absoluteUrl)>();
                    imagePublicIds.Add(imgTuple);
                }
            }
            var result = await _service.PackageService.UpdatePackage(packageId, packageDtoForUpdate, imagePublicIds);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
            );
        }
    }
}
