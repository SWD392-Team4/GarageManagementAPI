using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/workplaces/{garageId}/appointments")]
    [ApiController]
    public class AppointmentController : ApiControllerBase
    {
        public AppointmentController(IServiceManager service) : base(service)
        {
        }

        [HttpPost("{appointmentId:guid}/confirmation")]
        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Customer)}")]
        public async Task<IActionResult> ApproveAppointment(Guid garageId, Guid appointmentId, [FromBody] AppointmentConfirmationDto appointmentConfirmation)
        {
            var userId = User.FindFirstValue("UserId");
            var role = User.FindFirstValue("Role");

            var result = await _service.AppointmentService.ConfirmAppointment(garageId, appointmentId, new(userId!), role!, appointmentConfirmation);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Guid garageId, [FromBody] AppointmentDtoCreation appointmentDtoCreation)
        {
            Guid? userId = User.FindFirstValue("UserId") != null ? new Guid(User.FindFirstValue("UserId")!) : (Guid?)null;
            var role = User.FindFirstValue("Role");

            var result = await _service.AppointmentService.CreateAppointment(garageId, userId, role, appointmentDtoCreation);
            return result.Map(
                onSuccess: _ => Created(),
                onFailure: ProcessError
                );
        }

    }
}
