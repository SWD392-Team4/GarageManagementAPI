using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/garages")]
    [ApiController]
    public class GarageController : ApiControllerBase
    {
        public GarageController(IServiceManager service) : base(service) { }

        [HttpGet]
        public async Task<IActionResult> GetGarages([FromQuery] GarageParameters garageParameters)
        {
            var baseResult = await _service.GarageService.GetAllGaragesAsync(
                garageParameters: garageParameters,
                trackChanges: false);

            return baseResult.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

        [HttpGet("{garageId:guid}", Name = "GarageById")]
        public async Task<IActionResult> GetGarage(
            Guid garageId,
            [FromQuery] GarageParameters garageParameters)
        {
            var baseResult = await _service.GarageService.GetGarageAsync(
                garageId,
                garageParameters,
                false);

            return baseResult.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

        [HttpPost(Name = "CreateGarage")]
        public async Task<IActionResult> CreateGarage([FromBody] GarageForCreationDto garageForCreationDto)
        {
            var baseResult = await _service.GarageService.CreateGarageAsync(garageForCreationDto);

            return baseResult.Map(
                onSuccess: result =>
                {
                    var createdGarage = baseResult.GetValue<GarageDtoWithRelation>();

                    return CreatedAtRoute("GarageById", new { garageId = createdGarage.Id }, baseResult);
                },
                onFailure: result => ProcessError(result));
        }

        [HttpPut("{garageId:guid}")]
        public async Task<IActionResult> UpdateGarage(Guid garageId, [FromBody] GarageForUpdateDto garageForUpdateDto)
        {
            var baseResult = await _service.GarageService
                .UpdateGarageAsync(
                garageId: garageId,
                garageForUpdateDto: garageForUpdateDto,
                trackChanges: true);

            return baseResult.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result));

        }

        [HttpPatch("{garageId:guid}")]
        public async Task<IActionResult> PartiallyUpdateGarage(Guid garageId, [FromBody] JsonPatchDocument<GarageForUpdateDto> garageDtoPatchDoc)
        {
            var baseResult = await _service.GarageService
                .GetGarageForPatchAsync(
                garageId: garageId,
                trackChanges: false);

            if (!baseResult.IsSuccess)
                return ProcessError(baseResult);

            var garageToPatch = baseResult.GetValue<GarageForUpdateDto>();

            garageDtoPatchDoc.ApplyTo(garageToPatch, ModelState);

            TryValidateModel(garageToPatch);
            if (!ModelState.IsValid)
                return await ModelState.InvalidModelSate();

            baseResult = await _service.GarageService
               .UpdateGarageAsync(
               garageId: garageId,
               garageForUpdateDto: garageToPatch,
               trackChanges: true);

            return baseResult.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result));
        }

        [HttpGet("{garageId:guid}/employees")]
        public async Task<IActionResult> GetEmployees(
            Guid garageId,
            [FromQuery] EmployeeParameters employeeParameters)
        {
            employeeParameters.GarageId = garageId;
            var baseResult = await _service.EmployeeService
                .GetEmployeesAsync(
                employeeParameters: employeeParameters,
                trackChanges: false);

            return baseResult.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

    }
}
