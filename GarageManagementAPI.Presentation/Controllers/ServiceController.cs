using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ApiControllerBase
    {
        public ServiceController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("categories")]
        public IActionResult GetServiceCategory()
        {
            var serviceCategories = Enum.GetValues<ServiceCategory>();
            return Ok(Result<IList<ServiceCategory>>.Ok(serviceCategories));
        }

        [HttpGet("actions")]
        public IActionResult GetServiceActions()
        {
            var serviceActions = Enum.GetValues<ServiceAction>();
            return Ok(Result<IList<ServiceAction>>.Ok(serviceActions));
        }

        [HttpGet("worknatures")]
        public IActionResult GetWorkNatures()
        {
            var workNatures = Enum.GetValues<WorkNature>();
            return Ok(Result<IList<WorkNature>>.Ok(workNatures));
        }

        /// <summary>
        /// Get all service
        /// </summary>
        /// <param name="serviceParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServices([FromQuery] ServiceParameters serviceParameters)
        {
            var include = "CarCategory, CarPart, ServiceImage, ServiceHistories";
            var serviceResult = await _service.ServiceService.GetServicesAsync(serviceParameters, trackChanges: false, include);

            return serviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("random")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetRamdomServices([FromQuery] int number = 5)
        {
            var include = "CarCategory, CarPart, ServiceImage, ServiceHistories";

            var serviceResult = await _service.ServiceService.GetTopService(number, trackChanges: false, include);

            return Ok(serviceResult);
        }

        /// <summary>
        /// Get service by id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("{serviceId:guid}", Name = "GetServiceById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId)
        {
            var include = "CarCategory, CarPart, ServiceImage, ServiceHistories";
            var setviceResult = await _service.ServiceService.GetServiceAsync(serviceId, trackChanges: false, include);

            return setviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get service by car category
        /// </summary>
        /// <param name="carCategoryId"></param>
        /// <param name="serviceParameters"></param>
        /// <returns></returns>

        [HttpGet("carCategory/{carCategoryId:guid}", Name = "GetCarCategory")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceByCarCategory(Guid carCategoryId, [FromRoute] ServiceParameters serviceParameters)
        {
            var include = "CarCategory, CarPart, ServiceImage, ServiceHistories";
            var setviceResult = await _service.ServiceService.GetServiceByCarCategory(carCategoryId, serviceParameters, trackChanges: false, include);

            return setviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get service by car model
        /// </summary>
        /// <param name="carModelId"></param>
        /// <param name="serviceParameters"></param>
        /// <returns></returns>
        [HttpGet("carModel/{carModelId:guid}", Name = "GetCarModel")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceByCarModel(Guid carModelId, [FromRoute] ServiceParameters serviceParameters)
        {
            var include = "CarCategory, CarPart, ServiceImage, ServiceHistories";
            var setviceResult = await _service.ServiceService.GetServiceByCarModel(carModelId, serviceParameters, trackChanges: false, include);

            return setviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> UpdateService(Guid serviceId, [FromBody] ServiceDtoForUpdate serviceDtoForUpdate)
        {
            var result = await _service.ServiceService
                .UpdateService(
                serviceId,
                serviceDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        /// <summary>
        /// Create service
        /// </summary>
        /// <param name="serviceDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateService")]
        public async Task<IActionResult> CreateService([FromBody] ServiceDtoForCreation serviceDtoForCreation)
        {
            var createServiceResult = await _service.ServiceService.CreateServiceAsync(serviceDtoForCreation);
            if (!createServiceResult.IsSuccess)
            {
                return ProcessError(createServiceResult);
            }
            var createdService = createServiceResult.GetValue<ServiceDto>();
            var getServiceResult = await GetServiceById(createdService.Id);

            return getServiceResult;
        }

        [HttpPost("{serviceId:guid}/images", Name = "Create service image")]
        public async Task<IActionResult> CreateServiceImage(Guid serviceId, [FromForm] List<IFormFile> fileDtos)
        {
            if (fileDtos == null || !fileDtos.Any())
            {
                return BadRequest("No files were uploaded.");
            }
            var createdServiceImages = new List<object>();
            foreach (var fileDto in fileDtos)
            {
                var uploadFileResult = await _service.MediaService.UploadProductImageAsync(fileDto);

                if (!uploadFileResult.IsSuccess) return ProcessError(uploadFileResult);

                var imgTuple = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();

                var updateResult = await _service.ServiceImageService.CreateImageService(serviceId, imgTuple.publicId!, imgTuple.absoluteUrl!);

                if (!updateResult.IsSuccess) return ProcessError(updateResult);

                createdServiceImages.Add(updateResult.Value!.ImageLink!);
            }

            return Ok(createdServiceImages);
        }

        /// <summary>
        /// Update service by field
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("{serviceId:guid}")]
        public async Task<IActionResult> PartiallyUpdateService(
                                                Guid serviceId,
                                                [FromBody] JsonPatchDocument<ServiceDtoForUpdate> jsonPatchDocumentDto,
                                                [FromServices] IValidator<ServiceDtoForUpdate> validator)
        {
            // Retrieve the existing brand data
            var serviceDtoForUpdateToPatchResult = await _service.BrandService.GetBrandForPartiallyUpdate(serviceId, trackChanges: false);
            if (!serviceDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(serviceDtoForUpdateToPatchResult);

            var serviceDtoForUpdateToPatch = serviceDtoForUpdateToPatchResult.GetValue<ServiceDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(serviceDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(serviceDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            // Update the brand
            var result = await _service.ServiceService.UpdateService(serviceId, serviceDtoForUpdateToPatch, trackChanges: true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
