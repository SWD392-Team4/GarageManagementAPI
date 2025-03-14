using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
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

        //[HttpPost("{appointmentId:guid}/confirmation")]
        //public async Task<IActionResult> ApproveAppointment(Guid garageId, Guid appointmentId, [FromBody] AppointmentDtoForConfirmation appointmentConfirmation)
        //{
        //    var userId = User.FindFirstValue("UserId");
        //    var role = User.FindFirstValue("Role");

        //    var result = await _service.AppointmentService.ConfirmAppointment(garageId, appointmentId, new(userId!), role!, appointmentConfirmation);

        //    return result.Map(
        //        onSuccess: Ok,
        //        onFailure: ProcessError
        //        );
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments(Guid garageId, [FromQuery] AppointmentParameters appointmentParameters)
        {
            var result = await _service.AppointmentService.GetAppointments(garageId, appointmentParameters);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{appointmentId:guid}", Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointment(Guid garageId, Guid appointmentId, string? fields)
        {
            var result = await _service.AppointmentService.GetAppointment(garageId, appointmentId, fields);
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

    }
}
