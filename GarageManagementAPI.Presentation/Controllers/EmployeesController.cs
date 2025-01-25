using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ApiControllerBase
    {
        public EmployeesController(IServiceManager service) : base(service) { }

        [HttpGet("{employeeId:guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployee(
            Guid employeeId,
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeeAsync(
                employeeId: employeeId,
                employeeParameters: employeeParameters,
                trackChanges: false);

            return baseResult.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeesAsync(
                employeeParameters: employeeParameters,
                trackChanges: false);

            return baseResult.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            [FromBody] EmployeeForCreationDto employeeForCreationDto)
        {
            var baseResult = await _service.EmployeeService
                .CreateEmployeeAsync(
                employeeForCreationDto: employeeForCreationDto,
                trackChanges: false);

            return baseResult.Map(
                onSuccess: result =>
                {
                    var createdEmployee = baseResult.GetValue<EmployeeDto>();

                    return CreatedAtRoute("GetEmployeeById", new
                    {
                        employeeId = createdEmployee.Id
                    }, baseResult);
                },
                onFailure: result => ProcessError(baseResult));
        }

        [HttpPut("{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployee(
            Guid employeeId,
            [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            var baseResult = await _service.EmployeeService
                .UpdateEmployeeAsync(
                employeeId: employeeId,
                employeeForUpdateDto: employeeForUpdateDto,
                employeeTrackChanges: true);

            return baseResult.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result));

        }

        [HttpPatch("{employeeId:guid}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForGarage(
            Guid employeeId,
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> employeeDtoPatchDoc)
        {
            var baseResult = await _service.EmployeeService
                .GetEmployeeForPatchAsync(
                employeeId: employeeId,
                false);

            if (!baseResult.IsSuccess)
                return ProcessError(baseResult);

            var employeeToPatch = baseResult.GetValue<EmployeeForUpdateDto>();

            employeeDtoPatchDoc.ApplyTo(employeeToPatch, ModelState);

            TryValidateModel(employeeToPatch);
            if (!ModelState.IsValid)
                return await ModelState.InvalidModelSate();

            baseResult = await _service.EmployeeService
               .UpdateEmployeeAsync(
               employeeId: employeeId,
               employeeForUpdateDto: employeeToPatch,
               employeeTrackChanges: true);

            return baseResult.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
                );
        }


    }
}
