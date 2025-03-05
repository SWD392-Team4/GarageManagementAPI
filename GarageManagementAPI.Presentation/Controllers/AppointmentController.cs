using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ApiControllerBase
    {
        public AppointmentController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentParameters appointmentParameters)
        {
            var result = await _service.AppointmentService.GetAppointmentsAsync(appointmentParameters, false);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{appointmentId:guid}", Name = "GetAppointmentById")]
        public async Task<IActionResult> GetAppointment(Guid appointmentId)
        {
            var result = await _service.AppointmentService.GetAppointmentAsync(appointmentId, false);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "CreateAppointment")]
        public async Task<IActionResult> CreateWorkplace([FromBody] AppointmentDtoForCreate appointmentDtoForCreate)
        {
            var result = await _service.AppointmentService.CreateAppointment(appointmentDtoForCreate);

            return result.Map(
                onSuccess: result =>
                {
                    var createdAppointment = result.GetValue<AppointmentDto>();

                    return CreatedAtRoute("GetAppointmentById", new { appointmentId = createdAppointment.Id }, result);
                },
                onFailure: ProcessError
                );
        }
    }
}
