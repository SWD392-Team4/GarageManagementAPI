using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/garages")]
    [ApiController]
    public class GarageController : ApiControllerBase
    {
        private readonly IServiceManager _service;

        public GarageController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGarages([FromQuery] GarageParameters garageParameters)
        {
            var baseResult = await _service.GarageService.GetAllGaragesAsync(
                garageParameters: garageParameters,
                trackChanges: false);

            var pagedResult = baseResult.GetResult<PageInfo>();

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult.items);
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

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            var garage = baseResult.GetResult<ExpandoObject>();

            return Ok(garage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGarage([FromBody] GarageForCreationDto garageForCreationDto)
        {
            if (garageForCreationDto == null) return BadRequest("GarageForCreationDto is null");

            var baseResult = await _service.GarageService.CreateGarageAsync(garageForCreationDto);

            var createdGarage = baseResult.GetResult<GarageDtoWithRelation>();

            return CreatedAtRoute("GarageById", new { garageId = createdGarage.Id }, createdGarage);
        }

        [HttpPut("{garageId:guid}")]
        public async Task<IActionResult> UpdateGarage(Guid garageId, [FromBody] GarageForUpdateDto garageForUpdateDto)
        {
            var baseResult = await _service.GarageService
                .UpdateGarageAsync(
                garageId: garageId,
                garageForUpdateDto: garageForUpdateDto,
                trackChanges: true);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            return NoContent();

        }

        [HttpPatch("{garageId:guid}")]
        public async Task<IActionResult> PartiallyUpdateGarage(Guid garageId, [FromBody] JsonPatchDocument<GarageForUpdateDto> garageDtoPatchDoc)
        {
            var baseResult = await _service.GarageService
                .GetGarageForPatchAsync(
                garageId: garageId,
                trackChanges: false);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            var garageToPatch = baseResult.GetResult<GarageForUpdateDto>();

            garageDtoPatchDoc.ApplyTo(garageToPatch, ModelState);

            TryValidateModel(garageToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            baseResult = await _service.GarageService
               .UpdateGarageAsync(
               garageId: garageId,
               garageForUpdateDto: garageToPatch,
               trackChanges: true);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            return NoContent();
        }
    }
}
