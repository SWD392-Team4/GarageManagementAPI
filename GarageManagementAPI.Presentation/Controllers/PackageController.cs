using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ApiControllerBase
    {
        public PackageController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("type")]
        public IActionResult GetPackageTypes()
        {
            var packageTypes = Enum.GetValues<PackageType>();
            return Ok(Result<IList<PackageType>>.Ok(packageTypes));
        }

        [HttpGet("status")]
        public IActionResult GetPackageStatus()
        {
            var packgeHistoryStatus = Enum.GetValues<PackageStatus>();
            return Ok(Result<IList<PackageStatus>>.Ok(packgeHistoryStatus));
        }

        [HttpGet("timeUnit")]
        public IActionResult GetPackageTimeUnit()
        {
            var timeUnits = Enum.GetValues<TimeUnit>();
            return Ok(Result<IList<TimeUnit>>.Ok(timeUnits));
        }

        [HttpGet("ConditionType")]
        public IActionResult GetPackageConditionType()
        {
            var conditionTypes = Enum.GetValues<PackageConditionType>();
            return Ok(Result<IList<PackageConditionType>>.Ok(conditionTypes));
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
        public async Task<IActionResult> GetPackageById(Guid packageId, [FromQuery] string? fields)
        {
            var result = await _service.PackageService
                .GetPackageByIdAsync(packageId, false, fields);

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPost(Name = "CreatePacakge")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> CreatePacakge([FromQuery] string? fields, [FromForm] IList<IFormFile>? imagePackage, [FromForm] PackageDtoForCreation packageDtoForCreationompany)
        {
            if (imagePackage is not null && imagePackage.Count >= 5)
                return BadRequest(Result.BadRequest(RequestErrors.GetTooManyImageUploadErrors()));

            List<(string? publicId, string? absoluteUrl)>? imagePublicIds = null;

            if (imagePackage is not null)
            {
                imagePublicIds = [];
                foreach (var image in imagePackage)
                {
                    var uploadImageResult = await _service.MediaService.UploadPackageImageAsync(image);
                    if (!uploadImageResult.IsSuccess)
                        return ProcessError(uploadImageResult);

                    var imgTuple = uploadImageResult.GetValue<(string? publicId, string? absoluteUrl)>();
                    imagePublicIds.Add(imgTuple);
                }
            }
            var result = await _service.PackageService.CreatePackageAsync(packageDtoForCreationompany, imagePublicIds, fields);

            return result.Map(
                onSuccess: result =>
                {
                    var createdPackage = result.GetValue<ExpandoObject>();
                    var packageId = createdPackage
                        .FirstOrDefault(kv => kv.Key.Equals("id", StringComparison.InvariantCultureIgnoreCase)).Value;

                    return CreatedAtRoute("GetPackageById", new { packageId }, result);
                },
                onFailure: ProcessError
            );
        }

        [HttpPut("{packageId:guid}", Name = "UpdatePackage")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> UpdatePackage(Guid packageId, [FromBody] PackageDtoForUpdate packageDtoForUpdate)
        {
            var result = await _service.PackageService.UpdatePackageAsync(packageId, packageDtoForUpdate);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
            );
        }

        [HttpDelete("{packageId:guid}", Name = "DeletePackage")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> DeletePackage(Guid packageId)
        {
            var result = await _service.PackageService.RemovePacakgeAsync(packageId);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
            );
        }
    }
}
