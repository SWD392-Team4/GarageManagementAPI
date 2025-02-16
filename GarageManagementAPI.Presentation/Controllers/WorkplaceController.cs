using FluentValidation;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces")]
    [ApiController]
    public class WorkplaceController : ApiControllerBase
    {
        public WorkplaceController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkplace([FromQuery] WorkplaceParameters workplaceParameters)
        {
            var result = await _service.WorkplaceService
                .GetWorkplaces(
                workplaceParameters: workplaceParameters,
                trackChanges: false
                );

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{workpaceId:guid}", Name = "GetWorkplaceById")]
        public async Task<IActionResult> GetWorkplace(Guid workpaceId, [FromQuery] WorkplaceParameters workplaceParameters)
        {
            var result = await _service.WorkplaceService
                .GetWorkplace(
                workplaceId: workpaceId,
                workplaceParameters: workplaceParameters,
                trackChanges: false
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPost(Name = "CreateWorkplace")]
        public async Task<IActionResult> CreateWorkplace([FromBody] WorkplaceDtoForCreation workplaceDtoForCreation)
        {
            var result = await _service.WorkplaceService.CreateWorkplace(workplaceDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdWorkplace = result.GetValue<WorkplaceDto>();

                    return CreatedAtRoute("GetWorkplaceById", new { workpaceId = createdWorkplace.Id }, result);
                },
                onFailure: ProcessError
                );
        }


        [HttpPut("{workplaceId:guid}")]
        public async Task<IActionResult> UpdateWorkplace(Guid workplaceId, [FromBody] WorkplaceDtoForUpdate workplaceDtoForUpdate)
        {
            var result = await _service.WorkplaceService
                .UpdateWorkplace(
                workplaceId: workplaceId,
                workplaceDtoForUpdate: workplaceDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPatch("{workplaceId:guid}")]
        public async Task<IActionResult> PartiallyUpdateWorkplace(Guid workplaceId, [FromBody] JsonPatchDocument<WorkplaceDtoForUpdate> jsonPatchDocumentDto, IValidator<WorkplaceDtoForUpdate> validator)
        {
            var workplaceDtoForUpdateToPatchResult = await _service.WorkplaceService.GetWorkplaceForPartiallyUpdate(workplaceId, false);

            if (!workplaceDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(workplaceDtoForUpdateToPatchResult);

            var workplaceDtoForUpdateToPatch = workplaceDtoForUpdateToPatchResult.GetValue<WorkplaceDtoForUpdate>();

            jsonPatchDocumentDto.ApplyTo(workplaceDtoForUpdateToPatch, ModelState);

            var validationResult = validator.Validate(workplaceDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            var result = await _service.WorkplaceService
                .UpdateWorkplace(
                workplaceId: workplaceId,
                workplaceDtoForUpdate: workplaceDtoForUpdateToPatch,
                trackChanges: true
                );

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result));
        }
    }
}
