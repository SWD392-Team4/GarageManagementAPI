using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;

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

        [HttpGet]
        [Authorize(Roles = $"{nameof(SystemRole.Customer)}, {nameof(SystemRole.Cashier)}, {nameof(SystemRole.Administrator)}")]
        public async Task<IActionResult> GetAllAppointments(Guid garageId, [FromQuery] AppointmentParameters appointmentParameters)
        {
            var userId = User.FindFirstValue("UserId");
            var role = User.FindFirstValue("Role");

            var result = await _service.AppointmentService.GetAppointments(garageId, appointmentParameters, new(userId!), role!);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{appointmentId:guid}", Name = "GetAppointment")]
        [Authorize(Roles = $"{nameof(SystemRole.Customer)}, {nameof(SystemRole.Cashier)}, {nameof(SystemRole.Cashier)}, {nameof(SystemRole.Administrator)}")]
        public async Task<IActionResult> GetAppointment(Guid garageId, Guid appointmentId, string? fields)
        {
            var result = await _service.AppointmentService.GetAppointment(garageId, appointmentId, fields);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpGet("guest")]
        public async Task<IActionResult> GetAppointment(Guid garageId, [FromQuery] AppointmentDtoForGuest appointmentDtoForGuest)
        {
            var result = await _service.AppointmentService.GetAppointmentForGuest(garageId, appointmentDtoForGuest);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Guid garageId, [FromBody] AppointmentDtoForCreation appointmentDtoCreation)
        {
            Guid? userId = User.FindFirstValue("UserId") != null ? new Guid(User.FindFirstValue("UserId")!) : (Guid?)null;

            var result = await _service.AppointmentService.CreateAppointment(garageId, userId, appointmentDtoCreation);

            if (!result.IsSuccess)
                return ProcessError(result);

            var appointment = result.GetValue<AppointmentDto>();

            await _service.MailService.SendInformationAppointmentEmail(appointment.Id);

            return CreatedAtRoute("GetAppointment", new { garageId, appointmentId = appointment.Id }, result);
        }

        [HttpPost("checkPirce")]
        public async Task<IActionResult> CheckPrice([FromBody] AppointmentDtoForCheckPriceRequest appointmentDtoCreation)
        {
            var result = await _service.AppointmentService.CheckPriceAppointment(appointmentDtoCreation);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpPut("{appointmentId:guid}/confirmation")]
        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> ApproveAppointment(Guid garageId, Guid appointmentId, [FromBody] AppointmentDtoForConfirmation appointmentDtoConfirmation)
        {
            var userId = User.FindFirstValue("UserId");
            var role = User.FindFirstValue("Role");

            var result = await _service.AppointmentService.ConfirmAppointment(garageId, appointmentId, new(userId!), appointmentDtoConfirmation);

            if (!result.IsSuccess)
                return ProcessError(result);

            await _service.MailService.SendInformationAppointmentAfterConfirmationEmail(appointmentId);

            return Ok();
        }

        [HttpPut("guest/cancel")]
        public async Task<IActionResult> UpdateAppointment(Guid garageId, [FromBody] AppointmentDtoForGuestCancellation appointmentDtoForGuestCancellation)
        {
            var result = await _service.AppointmentService.CancelAppointmentForGuest(garageId, appointmentDtoForGuestCancellation);
            if (!result.IsSuccess)
                return ProcessError(result);


            await _service.MailService.SendInformationAppointmentAfterConfirmationEmail(result.Value!.Value);

            return Ok();
        }

        [HttpPut("{appointmentId:guid}/cancel")]
        [Authorize(Roles = $"{nameof(SystemRole.Customer)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> CancelAppointment(Guid garageId, Guid appointmentId, [FromBody] AppointmentDtoForCancellation appointmentDtoForCancellation)
        {
            var userId = User.FindFirstValue("UserId");
            var role = User.FindFirstValue("Role");
            var result = await _service.AppointmentService.CancelAppointment(garageId, appointmentId, new(userId!), role!, appointmentDtoForCancellation);

            if (!result.IsSuccess)
                return ProcessError(result);

            await _service.MailService.SendInformationAppointmentAfterConfirmationEmail(appointmentId);

            return Ok();
        }


        [HttpPut("{appointmentId:guid}")]
        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> UpdateAppointmentInformation(Guid garageId, Guid appointmentId, [FromBody] AppointmentDtoForUpdate appointmentDtoForUpdate)
        {
            var userId = User.FindFirstValue("UserId");
            var result = await _service.AppointmentService.UpdateAppointmentInformation(garageId, appointmentId, new(userId!), appointmentDtoForUpdate);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("{appointmentId:guid}/arrival")]
        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> UpdateAppointmentArrival(Guid garageId, Guid appointmentId, [FromBody] AppointmentDtoForUpdate appointmentDtoForUpdate)
        {
            var userId = User.FindFirstValue("UserId");
            var result = await _service.AppointmentService.UpdateAppointmentArrival(garageId, appointmentId, new(userId!), appointmentDtoForUpdate);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

    }
}
