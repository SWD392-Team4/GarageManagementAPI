using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/garages/{garageId}/employees")]
    [ApiController]
    public class EmployeesController : ApiControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployeesForGarage(Guid garageId)
        {
            var baseResult = _service.EmployeeService
                .GetEmployees(
                garageId: garageId,
                trackChanges: false);

            var employees = baseResult.GetResult<IEnumerable<EmployeeDto>>();

            return Ok(employees);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForGarage")]

        public IActionResult GetEmployeeForGarage(Guid garageId, Guid id)
        {
            var baseResult = _service.EmployeeService
                .GetEmployee(
                garageId: garageId,
                employeeId: id,
                trackChanges: false);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            var employee = baseResult.GetResult<EmployeeDto>();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForGarage(
            Guid garageId,
            [FromBody] EmployeeForCreationDto employeeForCreationDto)
        {
            var baseResult = _service.EmployeeService
                .CreateEmployeeForGarage(
                garageId: garageId,
                employeeForCreationDto: employeeForCreationDto,
                trackChanges: false);

            var createdEmployee = baseResult.GetResult<EmployeeDto>();

            return CreatedAtRoute("GetEmployeeForGarage", new
            {
                garageId,
                id = createdEmployee.Id
            }, createdEmployee);

        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForGarage(
            Guid garageId,
            Guid id,
            [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            var baseResult = _service.EmployeeService
                .UpdateEmployeeForGarage(
                garageId: garageId,
                employeeId: id,
                employeeForUpdateDto: employeeForUpdateDto,
                garageTrackChanges: false,
                employeeTrackChanges: true);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            return NoContent();

        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateEmployeeForGarage(
            Guid garageId,
            Guid id,
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> employeePatchDoc)
        {

            var baseResult = _service.EmployeeService.UpdateEmployeeForGarage(
                garageId: garageId,
                employeeId: id,
                employeePatchDoc: employeePatchDoc,
                garageTrackChanges: false,
                employeeTrackChanges: true);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            return NoContent();
        }

    }
}
