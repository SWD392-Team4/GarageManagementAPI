using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/car-categories")]
    [ApiController]
    public class CarCategoryController : ApiControllerBase
    {
        public CarCategoryController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCategories([FromQuery] CarCategoryParameters carCategoryParameters)
        {
            var result = await _service.CarCategoryService.GetCarCategoriesAsync(carCategoryParameters, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{id:Guid}", Name = "GetCarCategoryById")]
        public async Task<IActionResult> GetCarCategoryById(Guid id)
        {
            var result = await _service.CarCategoryService.GetCarCategoryAsync(id, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarCategory([FromBody] CarCategoryDtoForCreate carCategoryDtoForCreate)
        {
            var result = await _service.CarCategoryService.CreateCarCategoryAsync(carCategoryDtoForCreate);

            return result.Map(
                onSuccess: result =>
                {
                    var createdCarCategory = result.GetValue<CarCategoryDto>();

                    return CreatedAtRoute("GetCarCategoryById", new { id = createdCarCategory.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateCarCategory(Guid id, [FromBody] CarCategoryDtoForUpdate carCategoryDtoForUpdate)
        {
            var result = await _service.CarCategoryService.UpdateCarCategoryAsync(id, carCategoryDtoForUpdate, true);

            return result.Map(
                 onSuccess: _ => NoContent(),
                 onFailure: ProcessError
                 );
        }
    }

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
            var result = await _service.CarModelService.GetCarModels(carModelParameters, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{id:Guid}", Name = "GetCarModelById")]
        public async Task<IActionResult> GetCarModelById(Guid id)
        {
            var result = await _service.CarModelService.GetCarModel(id, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel([FromBody] CarModelDtoForCreate carModelDtoForCreate)
        {
            var result = await _service.CarModelService.CreateCarModels(carModelDtoForCreate);

            return result.Map(
                onSuccess: result =>
                {
                    var createdCarModel = result.GetValue<CarModelDto>();

                    return CreatedAtRoute("GetCarModelById", new { id = createdCarModel.Id }, result);
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
