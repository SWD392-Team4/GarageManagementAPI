using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Cashier;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Customer;
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

        [HttpPost]
        public Task<IActionResult> CreateAppointmentForCustomer(Guid garageId, [FromBody] CustomerCreateAppointmentDto appointmentCreateDto)
        {
            var result = _service.AppointmentService.CreateAppointmentForCustomer(garageId, appointmentCreateDto);

        }

        [HttpPut("confirm/{appointmentId:guid}")]
        [Authorize(Roles = nameof(SystemRole.Cashier))]
        public async Task<IActionResult> ConfirmAppointment(Guid garageId, Guid appointmentId, [FromBody] CashierAppointmentDtoConfirmation confirmation)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("UserId")!);
            var result = await _service.AppointmentService.ConfirmAppointment(garageId, appointmentId, userId, confirmation);

            return result.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );

        }


    }
}
