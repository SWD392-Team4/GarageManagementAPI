using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetGarages()
        {
            var baseResult = _service.GarageService.GetAllGarages(false);

            var garages = baseResult.GetResult<IEnumerable<GarageDto>>();

            return Ok(garages);
        }

        [HttpGet("{id:guid}", Name = "GarageById")]
        public IActionResult GetGarage(Guid id)
        {
            var baseResult = _service.GarageService.GetGarage(id, false);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            var garage = baseResult.GetResult<GarageDto>();
            return Ok(garage);
        }

        [HttpPost]
        public IActionResult CreateGarage([FromBody] GarageForCreationDto garageForCreationDto)
        {
            if (garageForCreationDto == null) return BadRequest("GarageForCreationDto is null");

            var baseResult = _service.GarageService.CreateGarage(garageForCreationDto);

            var createdGarage = baseResult.GetResult<GarageDto>();

            return CreatedAtRoute("GarageById", new { id = createdGarage.Id }, createdGarage);
        }
    }
}
