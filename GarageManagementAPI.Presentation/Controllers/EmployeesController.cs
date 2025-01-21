using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/garages/{garageId}/employees")]
    [ApiController]
    public class EmployeesController : ApiControllerBase
    {

        public EmployeesController(IServiceManager service) : base(service) { }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForGarage(
            Guid garageId,
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeesAsync(
                garageId: garageId,
                employeeParameters: employeeParameters,
                trackChanges: false);

            var pagedResult = baseResult.GetResult<PageInfo>();

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult.items);
        }

        [HttpGet("{employeeId:guid}", Name = "GetEmployeeForGarage")]
        public async Task<IActionResult> GetEmployeeForGarage(
            Guid garageId,
            Guid employeeId,
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeeAsync(
                garageId: garageId,
                employeeId: employeeId,
                employeeParameters: employeeParameters,
                trackChanges: false);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            var employee = baseResult.GetResult<ExpandoObject>();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeForGarage(
            Guid garageId,
            [FromBody] EmployeeForCreationDto employeeForCreationDto)
        {
            var baseResult = await _service.EmployeeService
                .CreateEmployeeForGarageAsync(
                garageId: garageId,
                employeeForCreationDto: employeeForCreationDto,
                trackChanges: false);

            var createdEmployee = baseResult.GetResult<EmployeeDtoWithRelation>();

            return CreatedAtRoute("GetEmployeeForGarage", new
            {
                garageId,
                employeeId = createdEmployee.Id
            }, createdEmployee);

        }

        [HttpPut("{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployeeForGarage(
            Guid garageId,
            Guid employeeId,
            [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            var baseResult = await _service.EmployeeService
                .UpdateEmployeeForGarageAsync(
                garageId: garageId,
                employeeId: employeeId,
                employeeForUpdateDto: employeeForUpdateDto,
                garageTrackChanges: false,
                employeeTrackChanges: true);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            return NoContent();

        }

        [HttpPatch("{employeeId:guid}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForGarage(
            Guid garageId,
            Guid employeeId,
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> employeeDtoPatchDoc)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeeForPatchAsync(
                garageId: garageId,
                employeeId: employeeId,
                false);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            var employeeToPatch = baseResult.GetResult<EmployeeForUpdateDto>();

            employeeDtoPatchDoc.ApplyTo(employeeToPatch, ModelState);

            TryValidateModel(employeeToPatch);
            if (!ModelState.IsValid)
                return ModelState.InvalidModelSate();

            baseResult = await _service.EmployeeService
               .UpdateEmployeeForGarageAsync(
               garageId: garageId,
               employeeId: employeeId,
               employeeForUpdateDto: employeeToPatch,
               garageTrackChanges: false,
               employeeTrackChanges: true);

            if (!baseResult.Success)
                return await ProcessError(baseResult);

            return NoContent();
        }


    }
}
