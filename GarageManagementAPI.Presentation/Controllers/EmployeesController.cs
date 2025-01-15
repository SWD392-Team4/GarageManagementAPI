using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
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
            var baseResult = _service.EmployeeService.GetEmployees(garageId, false);

            var employees = baseResult.GetResult<IEnumerable<EmployeeDto>>();

            return Ok(employees);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForGarage")]

        public IActionResult GetEmployeeForGarage(Guid garageId, Guid id)
        {
            var baseResult = _service.EmployeeService.GetEmployee(garageId, id, false);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            var employee = baseResult.GetResult<EmployeeDto>();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForGarage(Guid garageId, [FromBody] EmployeeForCreationDto employeeForCreationDto)
        {
            var baseResult = _service.EmployeeService.CreateEmployeeForGarage(garageId, employeeForCreationDto, false);

            var createdEmployee = baseResult.GetResult<EmployeeDto>();

            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                garageId,
                id = createdEmployee.Id
            }, createdEmployee);

        }
    }
}
