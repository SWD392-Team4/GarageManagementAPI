using GarageManagementAPI.Service.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments/{appointmentId:guid}/details/{detailId}/assigned")]
    [ApiController]
    public class AssignedEmployeeController : ApiControllerBase
    {
        public AssignedEmployeeController(IServiceManager service) : base(service)
        {
        }
        [HttpPut]
        public async Task<IActionResult> AssignEmployee(Guid garageId, Guid appointmentId, Guid detailId, [FromBody] List<Guid> employeeIds)
        {
            var result = await _service.AppointmentDetailService.AssignEmployee(garageId, appointmentId, detailId, employeeIds);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        [HttpPut("cancel")]
        public async Task<IActionResult> CancelAssignedEmployee(Guid garageId, Guid appointmentId, Guid detailId, [FromBody] List<Guid> employeeIds)
        {
            var result = await _service.AppointmentDetailService.CancelAssignedEmployee(garageId, appointmentId, detailId, employeeIds);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
