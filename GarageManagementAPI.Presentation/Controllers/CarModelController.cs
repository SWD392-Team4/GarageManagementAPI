using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/car-models")]
    [ApiController]
    public class CarModelController : ApiControllerBase
    {
        public CarModelController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCarModels([FromQuery] CarModelParameters carModelParameters)
        {
            var include = "Brand, CarCategory";
            var result = await _service.CarModelService.GetCarModels(carModelParameters, false, include);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{id:Guid}", Name = "GetCarModelById")]
        public async Task<IActionResult> GetCarModelById(Guid id, [FromQuery] string? fields)
        {
            var include = "Brand, CarCategory";
            var result = await _service.CarModelService.GetCarModel(id, false, fields, include);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel([FromBody] CarModelDtoForCreate carModelDtoForCreate, [FromQuery] string? fields)
        {
            var result = await _service.CarModelService.CreateCarModels(carModelDtoForCreate, fields);

            return result.Map(
                onSuccess: result =>
                {
                    var createdCarModel = result.GetValue<ExpandoObject>();
                    var carModelId = createdCarModel
                        .FirstOrDefault(kv => kv.Key.Equals("id", StringComparison.InvariantCultureIgnoreCase)).Value;

                    return CreatedAtRoute("GetCarModelById", new { id = carModelId }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateCarModel(Guid id, [FromBody] CarModelDtoForUpdate carModelDtoForUpdate)
        {
            var result = await _service.CarModelService.UpdateCarModel(id, carModelDtoForUpdate, true);

            return result.Map(
                 onSuccess: _ => NoContent(),
                 onFailure: ProcessError
                 );
        }
    }
}
