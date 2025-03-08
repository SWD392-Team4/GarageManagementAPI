using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/packages/{packageId:guid}/conditions")]
    [ApiController]
    public class PackageConditionController : ApiControllerBase
    {
        public PackageConditionController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPackageConditions(Guid packageId, [FromQuery] PackageConditionParameters packageConditionParameters)
        {
            var result = await _service.PackageConditionService.GetPackageConditionsAsync(packageId, packageConditionParameters);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
             );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPackageCondition(Guid packageId, Guid id, [FromQuery] string? fields)
        {
            var result = await _service.PackageConditionService.GetPackageConditionAsync(packageId, id, fields);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
             );
        }

        [HttpPost]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> CreatePackageCondition(Guid packageId, [FromBody] PackageConditionDtoForCreation packageConditionDtoForCreation)
        {
            var result = await _service.PackageConditionService.CreatePackageConditionAsync(packageId, packageConditionDtoForCreation);
            return result.Map(
                onSuccess: result =>
                {
                    var packageConditionDto = result.GetValue<PackageConditionDto>();
                    return CreatedAtAction(nameof(GetPackageCondition), new { packageId, id = packageConditionDto.Id }, result);
                },
                onFailure: ProcessError
             );
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> UpdatePackageCondition(Guid packageId, Guid id, [FromBody] PackageConditionDtoForUpdate packageConditionDtoForUpdate)
        {
            var result = await _service.PackageConditionService.UpdatePackageConditionAsync(packageId, id, packageConditionDtoForUpdate);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
             );
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> RemovePackageCondition(Guid packageId, Guid id)
        {
            var result = await _service.PackageConditionService.RemovePackageConditionAsync(packageId, id);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
             );
        }

        [HttpDelete]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> RemovePackageConditions(Guid packageId)
        {
            var result = await _service.PackageConditionService.RemovePackageConditionAsync(packageId);
            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
             );
        }
    }
}
